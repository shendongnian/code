	public sealed class FormView {
		public IList<Action> Actions { get; private set; }
		public IList<FormGroup> Groups { get; private set; }
		public FormView(
			object obj) {
			if (obj == null) {
				throw new ArgumentNullException("obj");
			}
			var type = obj.GetType();
			var builder = FormLoader.Get(type);
			if (builder == null) {
				var message = string.Format("Unable to find form builder for type: {0}", type.FullName);
				throw new InvalidOperationException(message);
			}
			Actions = GetActions(builder);
			Groups = GetGroups(obj, builder);
		}
		private static IList<Action> GetActions(
			IFormMetadata builder) {
			return builder.ActionMetadatas.Select(
				a => new Action {
					Controller = a.Controller,
					Enctype = a.Enctype,
					FormId = a.FormId,
					IsDefault = a.Default,
					Label = a.Label,
					Name = a.Name
				}).ToList();
		}
		private static object GetFieldValue(
			object obj,
			PropertyInfo property,
			IFormPropertyMetadata propertyMetadata) {
			var value = property.GetValue(obj, null);
			if (string.IsNullOrEmpty(propertyMetadata.Format)) {
				return value;
			}
			return string.Format(propertyMetadata.Format, value);
		}
		private static IList<FormField> GetFields(
			object obj,
			string group,
			IList<PropertyInfo> properties,
			IList<IFormPropertyMetadata> propertyMetadatas) {
			return properties.Select(
				p => {
					var propertyMetadata = propertyMetadatas.SingleOrDefault(
						pm =>
							!pm.IsIgnored
							&& pm.Name == p.Name);
					if (propertyMetadata == null) {
						return null;
					}
					return new {
						propertyMetadata.Group,
						propertyMetadata.Label,
						propertyMetadata.Name,
						propertyMetadata.Order,
						propertyMetadata.Required,
						propertyMetadata.Type,
						Value = GetFieldValue(obj, p, propertyMetadata)
					};
				}).Where(
				a =>
					a != null
					&& a.Group == group).OrderBy(
				a => a.Order).Select(
				a => new FormField {
					IsRequired = a.Required,
					Label = a.Label,
					Name = a.Name,
					Type = a.Type,
					Value = a.Value
				}).ToList();
		}
		private static IList<FormGroup> GetGroups(
			object obj,
			IFormMetadata builder) {
			var properties = obj.GetType().GetProperties();
			return builder.GroupMetadatas.Select(
				g => new {
					g.Label,
					g.Order,
					Fields = GetFields(obj, g.Label, properties, builder.PropertyMetadatas)
				}).OrderBy(
				a => a.Order).Select(
				a => new FormGroup {
					Label = a.Label,
					Fields = a.Fields
				}).ToList();
		}
		public sealed class Action {
			public string Controller { get; set; }
			public string Enctype { get; set; }
			public string FormId { get; set; }
			public bool IsDefault { get; set; }
			public string Label { get; set; }
			public string Name { get; set; }
		}
	}
