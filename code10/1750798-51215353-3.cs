	public interface IFormMetadata {
		IList<IFormActionMetadata> ActionMetadatas { get; }
		IList<IFormGroupMetadata> GroupMetadatas { get; }
		IList<IFormPropertyMetadata> PropertyMetadatas { get; }
	}
	public abstract class FormBuilder<TObject> :
		IFormMetadata {
		public IList<IFormActionMetadata> ActionMetadatas { get; private set; }
		public IList<IFormGroupMetadata> GroupMetadatas { get; private set; }
		public IList<IFormPropertyMetadata> PropertyMetadatas { get; private set; }
		protected FormBuilder() {
			ActionMetadatas = new List<IFormActionMetadata>();
			GroupMetadatas = new List<IFormGroupMetadata> {
				new GroupBuilder()
			};
			PropertyMetadatas = typeof(TObject).GetProperties().Select(
				p => new PropertyBuilder(p.Name)).Cast<IFormPropertyMetadata>().ToList();
		}
		public IFormActionBuilder Action<TController>(
			Expression<Action<TController>> action)
			where TController : IController {
			var method = ((MethodCallExpression)action.Body).Method;
			var controller = typeof(TController).Name.Replace("Controller", null);
			var builder = new ActionBuilder(method.Name, controller);
			ActionMetadatas.Add(builder);
			return builder;
		}
		public IFormGroupBuilder Group(
			string label) {
			var builder = new GroupBuilder(label);
			GroupMetadatas.Add(builder);
			return builder;
		}
		public void Ignore<TProperty>(
			Expression<Func<TObject, TProperty>> expression) {
			var member = ((MemberExpression)expression.Body).Member;
			var propertyMetadata = PropertyMetadatas.SingleOrDefault(
				b => b.Name == member.Name);
			if (propertyMetadata == null) {
				return;
			}
			propertyMetadata.IsIgnored = true;
		}
		protected static T Placeholder<T>() {
			return default(T);
		}
		public IFormPropertyBuilder Property<TProperty>(
			Expression<Func<TObject, TProperty>> expression) {
			var member = ((MemberExpression)expression.Body).Member;
			return PropertyMetadatas.Single(
				b => b.Name == member.Name) as IFormPropertyBuilder;
		}
		public sealed class ActionBuilder :
			IFormActionBuilder,
			IFormActionMetadata {
			public string Controller { get; private set; }
			public bool Default { get; private set; }
			public string Enctype { get; private set; }
			public string FormId { get; private set; }
			public string Label { get; private set; }
			public string Name { get; private set; }
			public ActionBuilder(
				string action,
				string controller) {
				Controller = controller;
				Enctype = "application/x-www-form-urlencoded";
				FormId = "panel-form";
				Label = "Save";
				Name = action;
			}
			public IFormActionBuilder HasFormId(
				string formId) {
				FormId = formId;
				return this;
			}
			public IFormActionBuilder HasLabel(
				string label) {
				Label = label;
				return this;
			}
			public IFormActionBuilder IsDefault() {
				Default = true;
				return this;
			}
			public IFormActionBuilder IsFileUpload() {
				Enctype = "multipart/form-data";
				return this;
			}
		}
		public sealed class GroupBuilder :
			IFormGroupBuilder,
			IFormGroupMetadata {
			public string Label { get; private set; }
			public short Order { get; private set; }
			public GroupBuilder() {
			}
			public GroupBuilder(
				string label) {
				Label = label;
			}
			public IFormGroupBuilder HasOrder(
				short order) {
				Order = order;
				return this;
			}
		}
		public sealed class PropertyBuilder :
			IFormPropertyBuilder,
			IFormPropertyMetadata {
			private static readonly Type StringType;
			static PropertyBuilder() {
				StringType = typeof(string);
			}
			public string Format { get; private set; }
			public string Group { get; private set; }
			public bool IsIgnored { get; set; }
			public string Label { get; private set; }
			public string Name { get; private set; }
			public short Order { get; private set; }
			public bool Required { get; private set; }
			public FormFieldType Type { get; private set; }
			public PropertyBuilder(
				string name) {
				Name = name;
				Order = short.MaxValue;
				Required = !IsNullable(name);
				Type = FormFieldType.Text;
			}
			public IFormPropertyBuilder HasFormat(
				string format) {
				Format = format;
				return this;
			}
			public IFormPropertyBuilder HasLabel(
				string label) {
				Label = label;
				return this;
			}
			public IFormPropertyBuilder HasOrder(
				short order) {
				Order = order;
				return this;
			}
			public IFormPropertyBuilder HasType(
				FormFieldType type) {
				Type = type;
				return this;
			}
			public IFormPropertyBuilder InGroup(
				string group) {
				Group = group;
				return this;
			}
			public IFormPropertyBuilder IsHidden() {
				Type = FormFieldType.Hidden;
				return this;
			}
			private static bool IsNullable(
				string name) {
				var type = typeof(TObject).GetProperty(name).PropertyType;
				if (type == StringType) {
					return true;
				}
				return type.IsValueType
					&& Nullable.GetUnderlyingType(type) != null;
			}
			public IFormPropertyBuilder IsReadOnly() {
				Type = FormFieldType.None;
				return this;
			}
			public IFormPropertyBuilder IsRequired() {
				Required = true;
				return this;
			}
		}
	}
