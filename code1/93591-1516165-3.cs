	/// <summary>
	/// Class for dynamic parallel invoking of a MulticastDelegate.
	/// (C) 2009 Arsène von Wyss, avw@gmx.ch
	/// No warranties of any kind, use at your own risk. Copyright notice must be kept in the source when re-used.
	/// </summary>
	public static class ParallelInvoke {
		private class ParallelInvokeContext<TDelegate> where TDelegate: class {
			private static readonly DynamicMethod invoker;
			private static readonly Type[] parameterTypes;
			static ParallelInvokeContext() {
				if (!typeof(Delegate).IsAssignableFrom(typeof(TDelegate))) {
					throw new InvalidOperationException("The TDelegate type must be a delegate");
				}
				Debug.Assert(monitor_enter != null, "Could not find the method Monitor.Enter()");
				Debug.Assert(monitor_pulse != null, "Could not find the method Monitor.Pulse()");
				Debug.Assert(monitor_exit != null, "Could not find the method Monitor.Exit()");
				FieldInfo parallelInvokeContext_activeCalls = typeof(ParallelInvokeContext<TDelegate>).GetField("activeCalls", BindingFlags.Instance|BindingFlags.NonPublic);
				Debug.Assert(parallelInvokeContext_activeCalls != null, "Could not find the private field ParallelInvokeContext.activeCalls");
				FieldInfo parallelInvokeContext_arguments = typeof(ParallelInvokeContext<TDelegate>).GetField("arguments", BindingFlags.Instance|BindingFlags.NonPublic);
				Debug.Assert(parallelInvokeContext_arguments != null, "Could not find the private field ParallelInvokeContext.arguments");
				MethodInfo delegate_invoke = typeof(TDelegate).GetMethod("Invoke", BindingFlags.Instance|BindingFlags.Public);
				Debug.Assert(delegate_invoke != null, string.Format("Could not find the method {0}.Invoke()", typeof(TDelegate).FullName));
				if (delegate_invoke.ReturnType != typeof(void)) {
					throw new InvalidOperationException("The TDelegate delegate must not have a return value");
				}
				ParameterInfo[] parameters = delegate_invoke.GetParameters();
				parameterTypes = new Type[parameters.Length];
				invoker = new DynamicMethod(string.Format("Invoker<{0}>", typeof(TDelegate).FullName), typeof(void), new[] {typeof(ParallelInvokeContext<TDelegate>), typeof(object)},
				                            typeof(ParallelInvokeContext<TDelegate>), true);
				ILGenerator il = invoker.GetILGenerator();
				LocalBuilder args = (parameters.Length > 2) ? il.DeclareLocal(typeof(object[])) : null;
				bool skipLoad = false;
				il.BeginExceptionBlock();
				il.Emit(OpCodes.Ldarg_1); // the delegate we are going to invoke
				if (args != null) {
					Debug.Assert(args.LocalIndex == 0);
					il.Emit(OpCodes.Ldarg_0);
					il.Emit(OpCodes.Ldfld, parallelInvokeContext_arguments);
					il.Emit(OpCodes.Dup);
					il.Emit(OpCodes.Stloc_0);
					skipLoad = true;
				}
				foreach (ParameterInfo parameter in parameters) {
					if (parameter.ParameterType.IsByRef) {
						throw new InvalidOperationException("The TDelegate delegate must note have out or ref parameters");
					}
					parameterTypes[parameter.Position] = parameter.ParameterType;
					if (args == null) {
						il.Emit(OpCodes.Ldarg_0);
						il.Emit(OpCodes.Ldfld, parallelInvokeContext_arguments);
					} else if (skipLoad) {
						skipLoad = false;
					} else {
						il.Emit(OpCodes.Ldloc_0);
					}
					il.Emit(OpCodes.Ldc_I4, parameter.Position);
					il.Emit(OpCodes.Ldelem_Ref);
					if (parameter.ParameterType.IsValueType) {
						il.Emit(OpCodes.Unbox_Any, parameter.ParameterType);
					}
				}
				il.Emit(OpCodes.Callvirt, delegate_invoke);
				il.BeginFinallyBlock();
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Call, monitor_enter);
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Ldfld, parallelInvokeContext_activeCalls);
				il.Emit(OpCodes.Ldc_I4_1);
				il.Emit(OpCodes.Sub);
				il.Emit(OpCodes.Dup);
				Label noPulse = il.DefineLabel();
				il.Emit(OpCodes.Brtrue, noPulse);
				il.Emit(OpCodes.Stfld, parallelInvokeContext_activeCalls);
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Call, monitor_pulse);
				Label exit = il.DefineLabel();
				il.Emit(OpCodes.Br, exit);
				il.MarkLabel(noPulse);
				il.Emit(OpCodes.Stfld, parallelInvokeContext_activeCalls);
				il.MarkLabel(exit);
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Call, monitor_exit);
				il.EndExceptionBlock();
				il.Emit(OpCodes.Ret);
			}
			[Conditional("DEBUG")]
			private static void VerifyArgumentsDebug(object[] args) {
				for (int i = 0; i < parameterTypes.Length; i++) {
					if (args[i] == null) {
						if (parameterTypes[i].IsValueType) {
							throw new ArgumentException(string.Format("The parameter {0} cannot be null, because it is a value type", i));
						}
					} else if (!parameterTypes[i].IsAssignableFrom(args[i].GetType())) {
						throw new ArgumentException(string.Format("The parameter {0} is not compatible", i));
					}
				}
			}
			private readonly object[] arguments;
			private readonly WaitCallback invokeCallback;
			private int activeCalls;
			public ParallelInvokeContext(object[] args) {
				if (parameterTypes.Length > 0) {
					if (args == null) {
						throw new ArgumentNullException("args");
					}
					if (args.Length != parameterTypes.Length) {
						throw new ArgumentException("The parameter count does not match");
					}
					VerifyArgumentsDebug(args);
					arguments = args;
				} else if ((args != null) && (args.Length > 0)) {
					throw new ArgumentException("This delegate does not expect any parameters");
				}
				invokeCallback = (WaitCallback)invoker.CreateDelegate(typeof(WaitCallback), this);
			}
			public void QueueInvoke(Delegate @delegate) {
				Debug.Assert(@delegate is TDelegate);
				activeCalls++;
				ThreadPool.QueueUserWorkItem(invokeCallback, @delegate);
			}
		}
		private static readonly MethodInfo monitor_enter;
		private static readonly MethodInfo monitor_exit;
		private static readonly MethodInfo monitor_pulse;
		static ParallelInvoke() {
			monitor_enter = typeof(Monitor).GetMethod("Enter", BindingFlags.Static|BindingFlags.Public, null, new[] {typeof(object)}, null);
			monitor_pulse = typeof(Monitor).GetMethod("Pulse", BindingFlags.Static|BindingFlags.Public, null, new[] {typeof(object)}, null);
			monitor_exit = typeof(Monitor).GetMethod("Exit", BindingFlags.Static|BindingFlags.Public, null, new[] {typeof(object)}, null);
		}
		public static void Invoke<TDelegate>(TDelegate @delegate) where TDelegate: class {
			Invoke(@delegate, null);
		}
		public static void Invoke<TDelegate>(TDelegate @delegate, params object[] args) where TDelegate: class {
			if (@delegate == null) {
				throw new ArgumentNullException("delegate");
			}
			ParallelInvokeContext<TDelegate> context = new ParallelInvokeContext<TDelegate>(args);
			lock (context) {
				foreach (Delegate invocationDelegate in ((Delegate)(object)@delegate).GetInvocationList()) {
					context.QueueInvoke(invocationDelegate);
				}
				Monitor.Wait(context);
			}
		}
	}
