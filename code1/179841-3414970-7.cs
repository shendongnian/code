    using Castle.DynamicProxy;
	public class MixinFactory {
		/// <summary>
		/// Creates a mixin by comining all the interfaces implemented by objects array.
		/// </summary>
		/// <param name="objects">The objects to combine into one instance.</param>
		/// <returns></returns>
		public static object CreateMixin(params object[] objects) {
			ProxyGenerator generator = new ProxyGenerator();
			ProxyGenerationOptions options = new ProxyGenerationOptions();
			objects.ToList().ForEach(obj => options.AddMixinInstance(obj));
			return generator.CreateClassProxy<object>(options);
		}
		/// <summary>
		/// Creates a dynamic proxy of type TMixin. Members that called through this interface will be delegated to the first matched instance from the objects array
		/// It is up to the caller to make sure that objects parameter contains instances of all interfaces that TMixin implements
		/// </summary>
		/// <typeparam name="TMixin">The type of the mixin to return.</typeparam>
		/// <param name="objects">The objects that will be mixed in.</param>
		/// <returns>An instance of TMixin.</returns>
		public static TMixin CreateMixin<TMixin>(params object[] objects)
		where TMixin : class {
			if(objects.Any(o => o == null))
				throw new ArgumentNullException("All mixins should be non-null");
			ProxyGenerator generator = new ProxyGenerator();
			ProxyGenerationOptions options = new ProxyGenerationOptions();
			options.Selector = new MixinSelector();
			return generator.CreateInterfaceProxyWithoutTarget<TMixin>(options, objects.Select(o => new MixinInterceptor(o)).ToArray());
		}
	}
	public class MixinInterceptor : IInterceptor {
		private object m_Instance;
		public MixinInterceptor(object obj1) {
			this.m_Instance = obj1;
		}
		public Type ObjectType {
			get {
				return m_Instance.GetType();
			}
		}
		#region IInterceptor Members
		public void Intercept(IInvocation invocation) {
			invocation.ReturnValue = invocation.Method.Invoke(m_Instance, invocation.Arguments);
		}
		
		#endregion
	}
	public class MixinSelector : IInterceptorSelector{
		#region IInterceptorSelector Members
		public IInterceptor[] SelectInterceptors(Type type, System.Reflection.MethodInfo method, IInterceptor[] interceptors) {
			var matched = interceptors
				.OfType<MixinInterceptor>()
				.Where(mi => method.DeclaringType.IsAssignableFrom(mi.ObjectType))
				.ToArray();
			if(matched.Length == 0)
				throw new InvalidOperationException("Cannot match method " + method.Name + "on type " + method.DeclaringType.FullName + ". No interceptor for this type is defined");
			return matched;
		}
		#endregion
	}
