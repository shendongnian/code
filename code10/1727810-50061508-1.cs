    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.OData;
    using Microsoft.OData.Edm;
    
    namespace MHS.Assessments.WebAPI.Utilities
    {
        public static class IEdmModelBuilderExtensions
        {
            public static void AddAuthorizedRolesAnnotations(this IEdmModel edmModel)
            {
                var typeAnnotationsMapping = edmModel.SchemaElementsAcrossModels()
                    .OfType<IEdmEntityType>()
                    .Where(t => edmModel.GetAnnotationValue<ClrTypeAnnotation>(t) != null)
                    .Select(t => edmModel.GetAnnotationValue<ClrTypeAnnotation>(t).ClrType)
                    .ToDictionary(clrType => clrType,
                                  clrType => clrType.GetCustomAttributes<CanExpandAttribute>(inherit: false));
    
                foreach (var kvp in typeAnnotationsMapping)
                {
                    foreach (var attribute in kvp.Value)
                    {
                        attribute.SetRoles(edmModel, kvp.Key);
                    }
                }
            }
    
            public static void SetAuthorizedRolesOnType(this IEdmModel model,string typeName,string[] roles)
            {
                IEdmEntityType type = model.FindType(typeName) as IEdmEntityType;
                if (type == null)
                {
                    throw new InvalidOperationException("The authorized element must be an entity type");
                }
    
                model.SetAnnotationValue<AuthorizedRoles>(type, new AuthorizedRoles(roles));
            }
        }
    }
