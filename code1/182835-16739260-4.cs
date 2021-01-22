    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace HQ.Util.General
    {
        /// <summary>
        /// Usage is to have only one event for a recursive call on many objects
        /// </summary>
        public class LifeTrackerStack
        {
            // ******************************************************************
            protected readonly Action _stackCreationAction;
            protected readonly Action _stackDisposeAction;
            private int _refCount = 0;
            private object _objLock = new object();
            // ******************************************************************
            public LifeTrackerStack(Action stackCreationAction = null, Action stackDisposeAction = null)
            {
                _stackCreationAction = stackCreationAction;
                _stackDisposeAction = stackDisposeAction;
            }
    
            // ******************************************************************
            /// <summary>
            /// Return a new LifeTracker to be used in a 'using' block in order to ensure reliability
            /// </summary>
            /// <returns></returns>
            public LifeTracker GetNewLifeTracker()
            {
                LifeTracker lifeTracker = new LifeTracker(AddRef, RemoveRef);
    
                return lifeTracker;
            }
    
    		// ******************************************************************
    	    public int Count
    	    {
    			get { return _refCount; }
    	    }
    	
    		// ******************************************************************
    		public void Reset()
    		{
    			lock (_objLock)
    			{
    				_refCount = 0;
    				if (_stackDisposeAction != null)
    				{
    					_stackDisposeAction();
    				}
    			}
    		}
    		
    		// ******************************************************************
            private void AddRef()
            {
                lock (_objLock)
                {
                    if (_refCount == 0)
                    {
    					if (_stackCreationAction != null)
    					{
    						_stackCreationAction();
    					}
    				}
                    _refCount++;
                }
            }
    
            // ******************************************************************
            private void RemoveRef()
            {
                bool shouldDispose = false;
                lock (_objLock)
                {
                    if (_refCount > 0)
                    {
                        _refCount--;
                    }
    
                    if (_refCount == 0)
                    {
    					if (_stackDisposeAction != null)
    					{
    						_stackDisposeAction();
    					}
    				}
                }
            }
    
            // ******************************************************************
        }
    }
    using System;
    
    namespace HQ.Util.General
    {
    	public delegate void ActionDelegate();
    
        public class LifeTracker : IDisposable
        {
    		private readonly ActionDelegate _actionDispose;
    		public LifeTracker(ActionDelegate actionCreation, ActionDelegate actionDispose)
            {
                _actionDispose = actionDispose;
    
                if (actionCreation != null)
                    actionCreation();
            }
    
            private bool _disposed = false;
            public void Dispose()
            {
                Dispose(true);
                // This object will be cleaned up by the Dispose method.
                // Therefore, you should call GC.SupressFinalize to
                // take this object off the finalization queue
                // and prevent finalization code for this object
                // from executing a second time.
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                // Check to see if Dispose has already been called.
                if (!this._disposed)
                {
                    // If disposing equals true, dispose all managed
                    // and unmanaged resources.
                    if (disposing)
                    {
                        _actionDispose();
                    }
    
                    // Note disposing has been done.
                    _disposed = true;
                }
            }
        }
    }
