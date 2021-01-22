	using System;
	using System.Diagnostics;
	using System.Linq;
	using System.Collections;
	using System.Collections.Generic;
	using System.Threading;
	namespace EnumeratorTests
	{
		public enum EnumeratorEnumerableMode
		{
			NonBlocking,
			Blocking,
		}
		public sealed class EnumeratorEnumerable<T> : IEnumerable<T>
		{
			#region LockingEnumWrapper
			public sealed class LockingEnumWrapper : IEnumerator<T>
			{
				private static readonly HashSet<IEnumerator<T>> BusyTable = new HashSet<IEnumerator<T>>();
				private readonly IEnumerator<T> _wrap;
				internal LockingEnumWrapper(IEnumerator<T> wrap, EnumeratorEnumerableMode allowBlocking) 
				{
					_wrap = wrap;
					if (allowBlocking == EnumeratorEnumerableMode.Blocking)
						Monitor.Enter(_wrap);
					else if (!Monitor.TryEnter(_wrap))
						throw new InvalidOperationException("Thread conflict accessing busy Enumerator") {Source = "LockingEnumWrapper"};
					lock (BusyTable)
					{
						if (BusyTable.Contains(_wrap))
							throw new LockRecursionException("Self lock (deadlock) conflict accessing busy Enumerator") { Source = "LockingEnumWrapper" };
						BusyTable.Add(_wrap);
					}
					// always implicit Reset
					_wrap.Reset();
				}
				
				#region Implementation of IDisposable and IEnumerator
				public void Dispose()
				{
					lock (BusyTable)
						BusyTable.Remove(_wrap);
					Monitor.Exit(_wrap);
				}
				public bool MoveNext()      { return _wrap.MoveNext(); }
				public void Reset()         { _wrap.Reset(); }
				public T Current            { get { return _wrap.Current; } }
				object IEnumerator.Current  { get { return Current; } }
				#endregion
			}
			#endregion
			private readonly IEnumerator<T> _enumerator;
			private readonly EnumeratorEnumerableMode _allowBlocking;
			public EnumeratorEnumerable(IEnumerator<T> e, EnumeratorEnumerableMode allowBlocking)
			{
				_enumerator = e;
				_allowBlocking = allowBlocking;
			}
			private LockRecursionPolicy a;
			public IEnumerator<T> GetEnumerator()
			{
				return new LockingEnumWrapper(_enumerator, _allowBlocking);
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
		class TestClass
		{
			private static readonly string World = "hello world\n";
			public static void Main(string[] args)
			{
				var master = World.GetEnumerator();
				var nonblocking = new EnumeratorEnumerable<char>(master, EnumeratorEnumerableMode.NonBlocking);
				var blocking    = new EnumeratorEnumerable<char>(master, EnumeratorEnumerableMode.Blocking);
				foreach (var c in nonblocking)  Console.Write(c); // OK (implicit Reset())
				foreach (var c in blocking)     Console.Write(c); // OK (implicit Reset())
				foreach (var c in nonblocking)  Console.Write(c); // OK (implicit Reset())
				foreach (var c in blocking)     Console.Write(c); // OK (implicit Reset())
				try
				{
					var willRaiseException = from c1 in nonblocking from c2 in nonblocking select new {c1, c2};
					Console.WriteLine("Cartesian product: {0}", willRaiseException.Count()); // RAISE
				}
				catch (Exception e) { Console.WriteLine(e); }
				foreach (var c in nonblocking)  Console.Write(c); // OK (implicit Reset())
				foreach (var c in blocking)     Console.Write(c); // OK (implicit Reset())
				try
				{
					var willSelfLock = from c1 in blocking from c2 in blocking select new { c1, c2 };
					Console.WriteLine("Cartesian product: {0}", willSelfLock.Count()); // LOCK
				}
				catch (Exception e) { Console.WriteLine(e); }
				// should not externally throw (exceptions on other threads reported to console)
				if (ThreadConflictCombinations(blocking, nonblocking))
					throw new InvalidOperationException("Should have thrown an exception on background thread");
				if (ThreadConflictCombinations(nonblocking, nonblocking))
					throw new InvalidOperationException("Should have thrown an exception on background thread");
				if (ThreadConflictCombinations(nonblocking, blocking))
					Console.WriteLine("Background thread timed out");
				if (ThreadConflictCombinations(blocking, blocking))
					Console.WriteLine("Background thread timed out");
				Debug.Assert(true); // Must be reached
			}
			private static bool ThreadConflictCombinations(IEnumerable<char> main, IEnumerable<char> other)
			{
				try
				{
					using (main.GetEnumerator())
					{
						var bg = new Thread(o =>
							{
								try { other.GetEnumerator(); }
								catch (Exception e) { Report(e); }
							}) { Name = "background" };
						bg.Start();
						bool timedOut = !bg.Join(1000); // observe the thread waiting a full second for a lock (or throw the exception for nonblocking)
						if (timedOut)
							bg.Abort();
						return timedOut;
					}
				} catch
				{
					throw new InvalidProgramException("Cannot be reached");
				}
			}
			static private readonly object ConsoleSynch = new Object();
			private static void Report(Exception e)
			{
				lock (ConsoleSynch)
					Console.WriteLine("Thread:{0}\tException:{1}", Thread.CurrentThread.Name, e);
			}
		}
	}
