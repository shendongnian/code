    using System;
    using System.Threading;
    
    namespace HQ.Util.General
    {
    	public class ReferenceCounterTracker
    	{
    		private Action _actionOnCountReachZero = null;
    		private int _count = 0;
    
    		public ReferenceCounterTracker(Action actionOnCountReachZero)
    		{
    			_actionOnCountReachZero = actionOnCountReachZero;
    		}
    
    		public void AddRef()
    		{
    			Interlocked.Increment(ref _count);
    		}
    		
    		public void ReleaseRef()
    		{
    			int count = Interlocked.Decrement(ref _count);
    			if (count == 0)
    			{
    				if (_actionOnCountReachZero != null)
    				{
    					_actionOnCountReachZero();
    				}
    			}
    		}
    	}
    }
