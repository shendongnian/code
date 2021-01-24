	using System.Collections.Generic;
	using System.Data.Entity.Core.Mapping;
	using System.Data.Entity.Core.Metadata.Edm;
	using System.Data.Entity.Infrastructure;
	using System.Data.Entity.ModelConfiguration.Conventions;
	using System.Linq;
	namespace Habitus.Toolkit.Database
	{
		public class PrefixConvention : IStoreModelConvention<EdmProperty>
		{
			public void Apply(EdmProperty property, DbModel model)
			{
				if (property.Name == "Id" || property.Name == "Discriminator" || property.DeclaringType.IsView()) return;
				var fragments = model
					.ConceptualToStoreMapping
					.EntitySetMappings
					.SelectMany(esm => esm.EntityTypeMappings)
					.SelectMany(etm => etm.Fragments)
					.Where(f => f.StoreEntitySet.ElementType == property.DeclaringType)
					.ToList();
				var propertyMappings = fragments
					.SelectMany(f => f.PropertyMappings)
					.ToList();
				var path = GetPropertyPath(property, propertyMappings);
				if (path?.Any() == false)
				{
					throw new System.Exception($"Can't process property {property.DeclaringType.FullName}.{property.Name}");
				}
				var first = path.First();
				var names = path.Select(pm => pm.Name).ToList();
				property.Name = $"{first.DeclaringType.Name}__{string.Join("_", names)}";
			}
			private List<EdmProperty> GetPropertyPath(EdmProperty property, List<PropertyMapping> propertyMappings)
			{
				var result = new List<EdmProperty>();
				var scalarPropertyMapping = propertyMappings
					.OfType<ScalarPropertyMapping>()
					.Where(pm => pm.Column == property)
					.FirstOrDefault();
				if (scalarPropertyMapping != null)
				{
					result.Add(scalarPropertyMapping.Property);
				}
				else
				{
					var complexPropertyMappings = propertyMappings
						.OfType<ComplexPropertyMapping>()
						.ToList();
					foreach (var complexPropertyMapping in complexPropertyMappings)
					{
						var recursivePropertyMappings = complexPropertyMapping
							.TypeMappings
							.SelectMany(tm => tm.PropertyMappings)
							.ToList();
						var recursiveResult = GetPropertyPath(property, recursivePropertyMappings);
						if (recursiveResult.Any())
						{
							result.Add(complexPropertyMapping.Property);
							result.AddRange(recursiveResult);
							break;
						}
					}
				}
				return result;
			}
		}
	}
