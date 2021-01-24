	public static class FormLoader {
		private static IDictionary<Type, Builder> _builders;
		public static IFormMetadata Get<TObject>() {
			return Get(typeof(TObject));
		}
		public static IFormMetadata Get(
			Type type) {
			var builder = _builders[type];
			if (builder.Instance == null) {
				builder.Instance = Activator.CreateInstance(builder.Type) as IFormMetadata;
			}
			return builder.Instance;
		}
		public static void Initialize() {
			Initialize(Assembly.GetExecutingAssembly());
		}
		public static void Initialize(
			params Assembly[] assemblies) {
			var type = typeof(FormBuilder<>);
			_builders = assemblies.SelectMany(
				a => a.GetTypes()).Where(
				t =>
					!t.IsAbstract
					&& !t.IsInterface
					&& t.BaseType != null
					&& t.BaseType.IsGenericType
					&& t.BaseType.GetGenericTypeDefinition() == type).Select(
				t => new {
					ObjectType = t.BaseType.GetGenericArguments()[0],
					BuilderType = t
				}).ToDictionary(
				k => k.ObjectType,
				v => new Builder {
					Type = v.BuilderType
				});
		}
		private sealed class Builder {
			public IFormMetadata Instance { get; set; }
			public Type Type { get; set; }
		}
	}
