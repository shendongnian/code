    using Castle.DynamicProxy;
	public class MixInFactory {
		public static object CreateMixin(params object[] objects) {
			ProxyGenerator generator = new ProxyGenerator();
			ProxyGenerationOptions options = new ProxyGenerationOptions();
			objects.ToList().ForEach(obj => options.AddMixinInstance(obj));
			return generator.CreateClassProxy<object>(options);
		}
		public static TMixin CreateMixin<TMixin, T1, T2>(T1 obj1, T2 obj2) 
			where TMixin : class,T1,T2 {
			ProxyGenerator generator = new ProxyGenerator();
			ProxyGenerationOptions options = new ProxyGenerationOptions();
			return generator.CreateInterfaceProxyWithoutTarget<TMixin>(options, new MixinInterceptor(obj1, obj2));
		}
	}
	public class MixinInterceptor : IInterceptor {
		private object m_t1;
		private object m_t2;
		public MixinInterceptor(object t1, object t2) {
			m_t1 = t1;
			m_t2 = t2;
		}
		#region IInterceptor Members
		public void Intercept(IInvocation invocation) {
			if(invocation.Method.DeclaringType.IsAssignableFrom(m_t1.GetType())) {
				invocation.ReturnValue = invocation.Method.Invoke(m_t1, invocation.Arguments);
			}
			if(invocation.Method.DeclaringType.IsAssignableFrom(m_t2.GetType())) {
				invocation.ReturnValue = invocation.Method.Invoke(m_t2, invocation.Arguments);
			}
		}
		#endregion
	}
