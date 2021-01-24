    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AsyncVoidTest
    {
    	class Program
    	{
    		static async void GetSomethingFromAService()
    		{
    			await Task.Delay(2000);
    			throw new InvalidOperationException(nameof(GetSomethingFromAService));
    		}
    
    		static async Task<int> MyMethodAsync()
    		{
    			// call an ill-designed 3rd party async void method 
    			// and await its completion
    			var pump = new PumpingContext();
    			var startingTask = pump.Run(GetSomethingFromAService);
    			await Task.WhenAll(startingTask, pump.CompletionTask);
    			return 42;
    		}
    
    		static async Task Main(string[] args)
    		{
    			try
    			{
    				await MyMethodAsync();
    			}
    			catch (Exception ex)
    			{
    				// this will catch the exception thrown from GetSomethingFromAService
    				Console.WriteLine(ex);
    			}
    		}
    	}
    
    	/// <summary>
    	/// PumpingContext, based on Stephen Toub's AsyncPump
    	/// https://blogs.msdn.com/b/pfxteam/archive/2012/02/02/await-synchronizationcontext-and-console-apps-part-3.aspx
    	/// https://stackoverflow.com/q/49921403/1768303
    	/// </summary>
    	internal class PumpingContext : SynchronizationContext
    	{
    		private int _pendingOps = 0;
    
    		private readonly BlockingCollection<ValueTuple<SendOrPostCallback, object>> _callbacks =
    			new BlockingCollection<ValueTuple<SendOrPostCallback, object>>();
    
    		private readonly List<Exception> _exceptions = new List<Exception>();
    
    		private TaskScheduler TaskScheduler { get; }
    
    		public Task CompletionTask { get; }
    
    		public PumpingContext(CancellationToken token = default(CancellationToken))
    		{
    			var taskSchedulerTcs = new TaskCompletionSource<TaskScheduler>();
    
    			this.CompletionTask = Task.Run(() =>
    			{
    				SynchronizationContext.SetSynchronizationContext(this);
    				taskSchedulerTcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
    				try
    				{
    					// run a short-lived callback pumping loop on a pool thread
    					foreach (var callback in _callbacks.GetConsumingEnumerable(token))
    					{
    						try
    						{
    							callback.Item1.Invoke(callback.Item2);
    						}
    						catch (Exception ex)
    						{
    							_exceptions.Add(ex);
    						}
    					}
    				}
    				catch (Exception ex)
    				{
    					_exceptions.Add(ex);
    				}
    				finally
    				{
    					SynchronizationContext.SetSynchronizationContext(null);
    				}
    				if (_exceptions.Any())
    				{
    					throw new AggregateException(_exceptions);
    				}
    			}, token);
    
    			this.TaskScheduler = taskSchedulerTcs.Task.GetAwaiter().GetResult();
    		}
    
    		public Task Run(
    			Action voidFunc,
    			CancellationToken token = default(CancellationToken))
    		{
    			return Task.Factory.StartNew(() =>
    			{
    				OperationStarted();
    				try
    				{
    					voidFunc();
    				}
    				finally
    				{
    					OperationCompleted();
    				}
    			}, token, TaskCreationOptions.None, this.TaskScheduler);
    		}
    
    		public Task<TResult> Run<TResult>(
    			Func<Task<TResult>> taskFunc,
    			CancellationToken token = default(CancellationToken))
    		{
    			return Task.Factory.StartNew<Task<TResult>>(async () =>
    			{
    				OperationStarted();
    				try
    				{
    					return await taskFunc();
    				}
    				finally
    				{
    					OperationCompleted();
    				}
    			}, token, TaskCreationOptions.None, this.TaskScheduler).Unwrap();
    		}
    
    		// SynchronizationContext methods
    		public override SynchronizationContext CreateCopy()
    		{
    			return this;
    		}
    
    		public override void OperationStarted()
    		{
    			// called when async void method is invoked 
    			Interlocked.Increment(ref _pendingOps);
    		}
    
    		public override void OperationCompleted()
    		{
    			// called when async void method completes 
    			if (Interlocked.Decrement(ref _pendingOps) == 0)
    			{
    				_callbacks.CompleteAdding();
    			}
    		}
    
    		public override void Post(SendOrPostCallback d, object state)
    		{
    			_callbacks.Add((d, state));
    		}
    
    		public override void Send(SendOrPostCallback d, object state)
    		{
    			throw new NotImplementedException(nameof(Send));
    		}
    	}
    }
