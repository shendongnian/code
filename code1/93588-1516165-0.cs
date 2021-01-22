	/// <summary>
	/// Class for dynamic parallel invoking of a MulticastDelegate.
	/// (C) 2009 Arsène von Wyss, avw@gmx.ch
	/// No warranties of any kind, use at your own risk. Copyright notice must be kept in the source when re-used.
	/// </summary>
	/// <typeparam name="TDelegate">The type of the delegate.</typeparam>
	public class ParallelInvoke<TDelegate> where TDelegate: class {
		private class ParallelInvokeContext {
			private delegate void Invoker(TDelegate instance, ParallelInvokeContext context);
			private static readonly Invoker invoker = CreateInvoker();
			private static Invoker CreateInvoker() {
				if (!typeof(Delegate).IsAssignableFrom(typeof(TDelegate))) {
					throw new InvalidOperationException("The TDelegate type must be a delegate");
				}
				FieldInfo parallelInvokeContext_activeCalls = typeof(ParallelInvokeContext).GetField("activeCalls", BindingFlags.Instance | BindingFlags.NonPublic);
				Debug.Assert(parallelInvokeContext_activeCalls != null, "Could not find the private field ParallelInvokeContext.activeCalls");
				FieldInfo parallelInvokeContext_arguments = typeof(ParallelInvokeContext).GetField("arguments", BindingFlags.Instance | BindingFlags.NonPublic);
				Debug.Assert(parallelInvokeContext_arguments != null, "Could not find the private field ParallelInvokeContext.arguments");
				MethodInfo monitor_enter = typeof(Monitor).GetMethod("Enter", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(object) }, null);
				Debug.Assert(monitor_enter != null, "Could not find the method Monitor.Enter()");
				MethodInfo monitor_pulse = typeof(Monitor).GetMethod("Pulse", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(object) }, null);
				Debug.Assert(monitor_pulse != null, "Could not find the method Monitor.Pulse()");
				MethodInfo monitor_exit = typeof(Monitor).GetMethod("Exit", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(object) }, null);
				Debug.Assert(monitor_exit != null, "Could not find the method Monitor.Exit()");
				MethodInfo delegate_invoke = typeof(TDelegate).GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public);
				Debug.Assert(delegate_invoke != null, string.Format("Could not find the method {0}.Invoke()", typeof(TDelegate).FullName));
				if (delegate_invoke.ReturnType != typeof(Void)) {
					throw new InvalidOperationException("The TDelegate delegate must not have a return value");
				}
				DynamicMethod method = new DynamicMethod(string.Format("Invoker<{0}>", typeof(TDelegate).FullName), typeof(Void), new Type[] { typeof(TDelegate), typeof(object[]) }, typeof(ParallelInvokeContext), true);
				ILGenerator il = method.GetILGenerator();
				il.BeginExceptionBlock();
				il.Emit(OpCodes.Ldarg_0);
				foreach (ParameterInfo parameter in delegate_invoke.GetParameters()) {
					if (parameter.ParameterType.IsByRef) {
						throw new InvalidOperationException("The TDelegate delegate must note have out or ref parameters");
					}
					il.Emit(OpCodes.Ldarg_1);
					il.Emit(OpCodes.Ldfld, parallelInvokeContext_arguments);
					il.Emit(OpCodes.Ldc_I4, parameter.Position);
					il.Emit(OpCodes.Ldelem_Ref);
					il.Emit(OpCodes.Unbox_Any, parameter.ParameterType);
				}
				il.Emit(OpCodes.Callvirt, delegate_invoke);
				il.BeginFinallyBlock();
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Call, monitor_enter);
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Ldfld, parallelInvokeContext_activeCalls);
				il.Emit(OpCodes.Ldc_I4_1);
				il.Emit(OpCodes.Sub);
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Stfld, parallelInvokeContext_activeCalls);
				Label noPulse = il.DefineLabel();
				il.Emit(OpCodes.Brtrue, noPulse);
				il.Emit(OpCodes.Call, monitor_pulse);
				il.Emit(OpCodes.Ldarg_1);
				il.MarkLabel(noPulse);
				il.Emit(OpCodes.Call, monitor_exit);
				il.EndExceptionBlock();
				return (Invoker)method.CreateDelegate(typeof(Invoker));
			}
			private readonly object[] arguments;
			private int activeCalls;
			
			public ParallelInvokeContext(object[] args) {
				this.arguments = args;
			}
			
			public void QueueInvoke(Delegate @delegate) {
				Debug.Assert(@delegate is TDelegate);
				activeCalls++;
				ThreadPool.QueueUserWorkItem(InvokeCallback, @delegate);
			}
			
			private void InvokeCallback(object @delegate) {
				invoker((TDelegate)@delegate, this);
			}
		}
		
		public static void Invoke(TDelegate @delegate) {
			Invoke(@delegate, (object[])null);
		}
	
		public static void Invoke(TDelegate @delegate, params object[] args) {
			if (@delegate == null) {
				throw new ArgumentNullException("delegate");
			}
			// ToDo: add some argument checking (number and types of arguments)
			ParallelInvokeContext context = new ParallelInvokeContext(args);
			lock(context) {
				foreach (Delegate invocationDelegate in ((Delegate)(object)@delegate).GetInvocationList()) {
					context.QueueInvoke(invocationDelegate);
				}
				Monitor.Wait(context);
			}
		}
	}
