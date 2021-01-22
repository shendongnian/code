		public static long Calc(CalcHandler fn, int a, int b, int c)
		{
			return Run<long>(TimeSpan.FromSeconds(20), delegate { return fn(a, b, c); });
		}
		public static T Run<T>(TimeSpan timeout, Func<T> operation)
		{
			Exception error = null;
			T result = default(T);
			ManualResetEvent mre = new ManualResetEvent(false);
			System.Threading.ThreadPool.QueueUserWorkItem(
				delegate(object ignore)
				{
					try { result = operation(); }
					catch (Exception e) { error = e; }
					finally { mre.Set(); }
				}
			);
			if (!mre.WaitOne(timeout, true))
				throw new TimeoutException();
			if (error != null)
				throw new TargetInvocationException(error);
			return result;
		}
