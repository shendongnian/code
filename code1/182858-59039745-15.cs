    // Copyright (c) 2008 Daniel Grunwald
    // 
    // Permission is hereby granted, free of charge, to any person
    // obtaining a copy of this software and associated documentation
    // files (the "Software"), to deal in the Software without
    // restriction, including without limitation the rights to use,
    // copy, modify, merge, publish, distribute, sublicense, and/or sell
    // copies of the Software, and to permit persons to whom the
    // Software is furnished to do so, subject to the following
    // conditions:
    // 
    // The above copyright notice and this permission notice shall be
    // included in all copies or substantial portions of the Software.
    // 
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    // OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
    // HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    // WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    // FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    // OTHER DEALINGS IN THE SOFTWARE.
    
    /* Usage:
     * 
     * 
     * 
            public delegate void FileChangedHandler(object sender, FileSystemEventArgs e);
    
            [field: NonSerialized]
            private readonly SmartWeakEvent<FileChangedHandler> _weakFileChanged = new SmartWeakEvent<FileChangedHandler>();
    
            public event FileChangedHandler FileChanged
            {
                add
                {
                    _weakFileChanged.Add(value);
                }
                remove
                {
                    _weakFileChanged.Remove(value);
                }
            }
     *
     *
     */
    
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    namespace HQ.Util.General.WeakEvent
    {
    	/// <summary>
    	/// A class for managing a weak event.
    	/// </summary>
    	public sealed class SmartWeakEvent<T> where T : class
    	{
    		struct EventEntry
    		{
    			public readonly MethodInfo TargetMethod;
    			public readonly WeakReference TargetReference;
    
    			public EventEntry(MethodInfo targetMethod, WeakReference targetReference)
    			{
    				this.TargetMethod = targetMethod;
    				this.TargetReference = targetReference;
    			}
    		}
    
    		readonly List<EventEntry> eventEntries = new List<EventEntry>();
    
    		// EO: Added for ObservableCollectionWeak
    		public int CountOfDelegateEntry
    		{
    			get
    			{
    				RemoveDeadEntries();
    				return eventEntries.Count;
    			}
    		}
    
    		static SmartWeakEvent()
    		{
    			if (!typeof(T).IsSubclassOf(typeof(Delegate)))
    				throw new ArgumentException("T must be a delegate type");
    			MethodInfo invoke = typeof(T).GetMethod("Invoke");
    			if (invoke == null || invoke.GetParameters().Length != 2)
    				throw new ArgumentException("T must be a delegate type taking 2 parameters");
    			ParameterInfo senderParameter = invoke.GetParameters()[0];
    			if (senderParameter.ParameterType != typeof(object))
    				throw new ArgumentException("The first delegate parameter must be of type 'object'");
    			ParameterInfo argsParameter = invoke.GetParameters()[1];
    			if (!(typeof(EventArgs).IsAssignableFrom(argsParameter.ParameterType)))
    				throw new ArgumentException("The second delegate parameter must be derived from type 'EventArgs'");
    			if (invoke.ReturnType != typeof(void))
    				throw new ArgumentException("The delegate return type must be void.");
    		}
    
    		public void Add(T eh)
    		{
    			if (eh != null)
    			{
    				Delegate d = (Delegate)(object)eh;
    
    				if (d.Method.DeclaringType.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Length != 0)
    					throw new ArgumentException("Cannot create weak event to anonymous method with closure.");
    
    				if (eventEntries.Count == eventEntries.Capacity)
    					RemoveDeadEntries();
    				WeakReference target = d.Target != null ? new WeakReference(d.Target) : null;
    				eventEntries.Add(new EventEntry(d.Method, target));
    			}
    		}
    
    		void RemoveDeadEntries()
    		{
    			eventEntries.RemoveAll(ee => ee.TargetReference != null && !ee.TargetReference.IsAlive);
    		}
    
    		public void Remove(T eh)
    		{
    			if (eh != null)
    			{
    				Delegate d = (Delegate)(object)eh;
    				for (int i = eventEntries.Count - 1; i >= 0; i--)
    				{
    					EventEntry entry = eventEntries[i];
    					if (entry.TargetReference != null)
    					{
    						object target = entry.TargetReference.Target;
    						if (target == null)
    						{
    							eventEntries.RemoveAt(i);
    						}
    						else if (target == d.Target && entry.TargetMethod == d.Method)
    						{
    							eventEntries.RemoveAt(i);
    							break;
    						}
    					}
    					else
    					{
    						if (d.Target == null && entry.TargetMethod == d.Method)
    						{
    							eventEntries.RemoveAt(i);
    							break;
    						}
    					}
    				}
    			}
    		}
    
    		public void Raise(object sender, EventArgs e)
    		{
    			int stepExceptionHelp = 0;
    
    			try
    			{
    				bool needsCleanup = false;
    				object[] parameters = {sender, e};
    				foreach (EventEntry ee in eventEntries.ToArray())
    				{
    					stepExceptionHelp = 1;
    					if (ee.TargetReference != null)
    					{
    						stepExceptionHelp = 2;
    						object target = ee.TargetReference.Target;
    						if (target != null)
    						{
    							stepExceptionHelp = 3;
    							ee.TargetMethod.Invoke(target, parameters);
    						}
    						else
    						{
    							needsCleanup = true;
    						}
    					}
    					else
    					{
    						stepExceptionHelp = 4;
    						ee.TargetMethod.Invoke(null, parameters);
    					}
    				}
    				if (needsCleanup)
    				{
    					stepExceptionHelp = 5;
    					RemoveDeadEntries();
    				}
    
    				stepExceptionHelp = 6;
    			}
    			catch (Exception ex)
    			{
    				string appName = Assembly.GetEntryAssembly().GetName().Name;
    				if (!EventLog.SourceExists(appName))
    				{
    					EventLog.CreateEventSource(appName, "Application");
    					EventLog.WriteEntry(appName,
    						String.Format("Exception happen in 'SmartWeakEvent.Raise()': {0}. Stack: {1}. Additional int: {2}.", ex.Message, ex.StackTrace, stepExceptionHelp), EventLogEntryType.Error);
    				}
    
    				throw;
    			}
    		}
    	}
    }
    
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    using System.Xml.Serialization;
    using HQ.Util.General.Log;
    using HQ.Util.General.WeakEvent;
    using JetBrains.Annotations;
    
    // using System.Windows.Forms;
    
    // using Microsoft.CSharp.RuntimeBinder;
    
    // ATTENTION: Can only be used with Framework 4.0 and up
    
    namespace HQ.Util.General.Notification
    {
    	[Serializable]
    	public class NotifyPropertyChangedThreadSafeAsyncWeakBase : INotifyPropertyChanged
    	{
    		// ******************************************************************
    		[XmlIgnore]
    		[field: NonSerialized]
    		public SmartWeakEvent<PropertyChangedEventHandler> SmartPropertyChanged = new SmartWeakEvent<PropertyChangedEventHandler>();
    
    		[XmlIgnore]
    		[field: NonSerialized]
    		private Dispatcher _dispatcher = null;
    
    		// ******************************************************************
    		public event PropertyChangedEventHandler PropertyChanged
    		{
    			add
    			{
    				SmartPropertyChanged.Add(value);
    			}
    			remove
    			{
    				SmartPropertyChanged.Remove(value);
    			}
    		}
    
    		// ******************************************************************
    		[Browsable(false)]
    		[XmlIgnore]
    		public Dispatcher Dispatcher
    		{
    			get
    			{
    				if (_dispatcher == null)
    				{
    					_dispatcher = Application.Current?.Dispatcher;
    					if (_dispatcher == null)					
    					{ 
    						if (Application.Current?.MainWindow != null)
    						{
    							_dispatcher = Application.Current.MainWindow.Dispatcher;
    						}
    					}
    				}
    
    				return _dispatcher;
    			}
    			set
    			{
    				if (_dispatcher == null && _dispatcher != value)
    				{
    					Debug.Print("Dispatcher has changed??? ");
    				}
    
    				_dispatcher = value;
    			}
    		}
    
    		// ******************************************************************
    		[NotifyPropertyChangedInvocator]
    		protected void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
    		{
    			try
    			{
    				if (Dispatcher == null || Dispatcher.CheckAccess()) // Can be null in case of Console app
    				{
    					SmartPropertyChanged.Raise(this, new PropertyChangedEventArgs(propertyName));
    				}
    				else
    				{
    					Dispatcher.BeginInvoke(
    						new Action(() => SmartPropertyChanged.Raise(this, new PropertyChangedEventArgs(propertyName))));
    				}
    			}
    			catch (TaskCanceledException ex) // Prevent MT error when closing app...
    			{
    				Log.Log.Instance.AddEntry(LogType.LogException, "An exception occured when trying to notify.", ex);
    			}
    		}
    
    		// ******************************************************************
    		[NotifyPropertyChangedInvocator]
    		protected void NotifyPropertyChanged<T2>(Expression<Func<T2>> propAccess)
    		{
    			try
    			{
    				var asMember = propAccess.Body as MemberExpression;
    				if (asMember == null)
    					return;
    
    				string propertyName = asMember.Member.Name;
    
    				if (Dispatcher == null || Dispatcher.CheckAccess()) // Can be null in case of Console app
    				{
    					SmartPropertyChanged.Raise(this, new PropertyChangedEventArgs(propertyName));
    				}
    				else
    				{
    					Dispatcher.BeginInvoke(new Action(() => SmartPropertyChanged.Raise(this, new PropertyChangedEventArgs(propertyName))));
    				}
    			}
    			catch (TaskCanceledException ex) // Prevent MT error when closing app...
    			{
    				Log.Log.Instance.AddEntry(LogType.LogException, "An exception occured when trying to notify.", ex);
    			}
    
    		}
    
    
    
    		// ******************************************************************
    		protected bool UpdateField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    		{
    			if (!EqualityComparer<T>.Default.Equals(field, value))
    			{
    				field = value;
    				NotifyPropertyChanged(propertyName);
    				return true;
    			}
    			return false;
    		}
    
    		// ******************************************************************
    	}
    }
    
    
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    using HQ.Util.General.Notification;
    
    namespace HQ.Util.General
    {
    	/// <summary>
    	/// This is the centralized calss to obtain the Dispatcher in order to make sure to get the appropriate one (the MainWindow dispatcher).
    	/// If you need a specidifc thread dispatcher, please refer to System.Windows.Threading.Dispatcher or Dispatcher.CurrentDispatcher.
    	/// This dispatcher should be set at the initialization (start) of any GUI executable: ex: Global.Instance.Dispatcher = Application.Current.Dispatcher;
    
    	/// </summary>
    	public class Global : NotifyPropertyChangedThreadSafeAsyncWeakBase
    	{
    		public delegate void IsBusyChangeHandler(bool isBusy);
    
    		/// <summary>
    		/// This event happen only the UI thread in low priority
    		/// </summary>
    		public event IsBusyChangeHandler IsBusyChange;
    
    		private readonly ConcurrentStack<bool> _stackBusy = new ConcurrentStack<bool>();
    
    		// ******************************************************************
    		public static void Init(Dispatcher dispatcher)
    		{
    			Instance.Dispatcher = dispatcher;
    		}
    
    		// ******************************************************************
    		public static Global Instance = new Global();
    
    		// ******************************************************************
    		private Global()
    		{
    			_busyLifeTrackerStack = new LifeTrackerStack(() => PushState(), PullState);
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Will set busy state temporary until object is disposed where 
    		/// the state will be back to its previous state.
    		/// </summary>
    		/// <param name="isBusy"></param>
    		/// <returns></returns>
    		public LifeTracker GetDisposableBusyState(bool isBusy = true)
    		{
    			return new LifeTracker(() => PushState(isBusy), PullState);
    		}
    
    		// ******************************************************************
    		private bool _isBusy;
    
    		/// <summary>
    		/// This property should be use by the GUI part in order to control the mouse cursor
    		/// </summary>
    		public bool IsBusy
    		{
    			get => _isBusy;
    
    			private set
    			{
    				if (value == _isBusy) return;
    				_isBusy = value;
    				Dispatcher.BeginInvoke(new Action(() => IsBusyChange?.Invoke(_isBusy)), DispatcherPriority.ContextIdle);
    				NotifyPropertyChanged();
    			}
    		}
    
    		private readonly object _objLockBusyStateChange = new object();
    		// ******************************************************************
    		/// <summary>
    		/// Always prefer usage of "Using(Global.Instance.GetDisposableBusyState())" whenever possible.
    		/// Otherwise ensure to call Pull State to get back previous state of the cursor when action is 
    		/// completed
    		/// </summary>
    		/// <param name="isBusy"></param>
    		public void PushState(bool isBusy = true)
    		{
    			lock (_objLockBusyStateChange)
    			{
    				_stackBusy.Push(isBusy);
    				IsBusy = isBusy;
    			}
    		}
    
    		// ******************************************************************
    		public void PullState()
    		{
    			lock (_objLockBusyStateChange)
    			{
    				_stackBusy.TryPop(out bool isBusy);
    
    				if (_stackBusy.TryPeek(out isBusy))
    				{
    					IsBusy = isBusy;
    				}
    				else
    				{
    					IsBusy = false;
    				}
    			}
    		}
    
    		// ******************************************************************
    		private readonly LifeTrackerStack _busyLifeTrackerStack = null;
    
    		/// <summary>
    		/// Only kept for historical reason / compatibility with previous code
    		/// </summary>
    		[Obsolete("Use direct 'using(Gloabl.Instance.GetDisposableBusyState(isBusy))' which is simpler")]
    		public LifeTrackerStack BusyLifeTrackerStack
    		{
    			get { return _busyLifeTrackerStack; }
    		}
    
    		// ******************************************************************
    		// private int _latestVersionExecuted = 0;
    		private int _currentVersionRequired = 0;
    		private readonly object _objLockRunOnce = new object();
    
    		private readonly Dictionary<int, GlobalRunOncePerQueueData> _actionsToRunOncePerQueue =
    			new Dictionary<int, GlobalRunOncePerQueueData>();
    
    		private readonly int _countOfRequestInQueue = 0;
    
    		/// <summary>
    		/// It will record all action once per key and it
    		/// once per Dispatcher queue roll over (on ContextIdle).
    		/// When the dispatcher reach the DispatcherPriority.ContextIdle, it will
    		/// run all action once.
    		/// Thread safe... no action will be lost but can be run twice or more if
    		/// some are added by other thread(s) at the same time one is executed.
    		/// </summary>
    		/// EO: sorry for the name but it is the best found
    		/// <param name="key"></param>
    		/// <param name="action"></param>
    		public void RunOncePerQueueRollOnDispatcherThread(int key, Action action)
    		{
    			lock (_objLockRunOnce)
    			{
    				if (!_actionsToRunOncePerQueue.TryGetValue(key, out GlobalRunOncePerQueueData data))
    				{
    					data = new GlobalRunOncePerQueueData(action);
    					_actionsToRunOncePerQueue.Add(key, data);
    				}
    
    				_currentVersionRequired++;
    				data.VersionRequired = _currentVersionRequired;
    			}
    
    			if (_countOfRequestInQueue <= 1)
    			{
    				Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(ExecuteActions));
    			}
    		}
    
    		// ******************************************************************
    		private void ExecuteActions()
    		{
    			int versionExecute;
    
    			List<GlobalRunOncePerQueueData> datas = null;
    			lock (_objLockRunOnce)
    			{
    				versionExecute = _currentVersionRequired;
    				datas = _actionsToRunOncePerQueue.Values.ToList();
    			}
    
    			foreach (var data in datas)
    			{
    				data.Action();
    			}
    
    			lock (_objLockRunOnce)
    			{
    				List<int> keysToRemove = new List<int>();
    
    				foreach (var kvp in _actionsToRunOncePerQueue)
    				{
    					if (kvp.Value.VersionRequired <= versionExecute)
    					{
    						keysToRemove.Add(kvp.Key);
    					}
    				}
    
    				keysToRemove.ForEach(k => _actionsToRunOncePerQueue.Remove(k));
    
    				if (_actionsToRunOncePerQueue.Count == 0)
    				{
    					// _latestVersionExecuted = 0;
    					_currentVersionRequired = 0;
    				}
    				else
    				{
    					// _latestVersionExecuted = versionExecute;
    				}
    			}
    		}
    
    		// ******************************************************************
    	}
    }
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Threading;
    using HQ.Util.General;
    using HQ.Util.General.Notification;
    using Microsoft.VisualBasic.Devices;
    using System.Windows;
    using Mouse = System.Windows.Input.Mouse;
    using System.Threading;
    
    namespace HQ.Wpf.Util
    {
    	public class AppGlobal
    	{
    		// ******************************************************************
    		public static void Init(Dispatcher dispatcher)
    		{
    			if (System.Windows.Input.Keyboard.IsKeyDown(Key.LeftShift) || System.Windows.Input.Keyboard.IsKeyDown(Key.RightShift))
    			{
    				var res = MessageBox.Show($"'{AppInfo.AppName}' has been started with shift pressed. Do you want to wait for the debugger (1 minute wait)?", "Confirmation", MessageBoxButton.YesNo,
    					MessageBoxImage.Exclamation, MessageBoxResult.No);
    
    				if (res == MessageBoxResult.Yes)
    				{
    					var start = DateTime.Now;
    
    					while (!Debugger.IsAttached)
    					{
    						if ((DateTime.Now - start).TotalSeconds > 60)
    						{
    							break;
    						}
    						Thread.Sleep(100);
    					}
    				}
    			}
    
    			if (dispatcher == null)
    			{
    				throw new ArgumentNullException();
    			}
    
    			Global.Init(dispatcher);
    			Instance.Init();
    		}
    
    		// ******************************************************************
    		public static readonly AppGlobal Instance = new AppGlobal();
    
    		// ******************************************************************
    		private AppGlobal()
    		{
    		}
    
    		// ******************************************************************
    		private void Init()
    		{
    			Global.Instance.PropertyChanged += AppGlobalPropertyChanged;
    		}
    
    		// ******************************************************************
    		void AppGlobalPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    		{
    			if (e.PropertyName == "IsBusy")
    			{
    				if (Global.Instance.IsBusy)
    				{
    					if (Global.Instance.Dispatcher.CheckAccess())
    					{
    						Mouse.OverrideCursor = Cursors.Wait;
    					}
    					else
    					{
    						Global.Instance.Dispatcher.BeginInvoke(new Action(() => Mouse.OverrideCursor = Cursors.Wait));
    					}
    				}
    				else
    				{
    					if (Global.Instance.Dispatcher.CheckAccess())
    					{
    						Mouse.OverrideCursor = Cursors.Arrow;
    					}
    					else
    					{
    						Global.Instance.Dispatcher.BeginInvoke(new Action(() => Mouse.OverrideCursor = Cursors.Arrow));
    					}
    				}
    			}
    		}
    
    		// ******************************************************************
    	}
    }
    
    
    
    using HQ.Util.General;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    
    namespace HQ.Wpf.Util
    {
    	/// <summary>
    	/// Ensure window cursor is "normal" (arrow) when visible.
    	/// Usage: In Window class, define a member: OverrideCursorMtForWindow. Instantiate in constructor after Initialisation.
    	/// </summary>
    	public class WindowWithAutoBusyState
        {
            // ******************************************************************
            Window _window;
            bool _nextStateShoulBeVisible = true;
    
    		// ******************************************************************
    		public WindowWithAutoBusyState()
    		{
    
    		}
    
    		// ******************************************************************
    		public void Init(Window window)
            {
                _window = window;
    
    			_window.Cursor = Cursors.Wait;
                _window.Loaded += (object sender, RoutedEventArgs e) => _window.Cursor = Cursors.Arrow;
    
                _window.IsVisibleChanged += WindowIsVisibleChanged;
                _window.Closed += WindowClosed;
            }
    
            // ******************************************************************
            private void WindowIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (_window.IsVisible)
                {
                    if (_nextStateShoulBeVisible)
                    {
    					Global.Instance.PushState(false);
                        _nextStateShoulBeVisible = false;
                    }
                }
                else
                {
                    if (!_nextStateShoulBeVisible)
                    {
    					Global.Instance.PullState();
                        _nextStateShoulBeVisible = true;
                    }
                }
            }
    
            // ******************************************************************
            private void WindowClosed(object sender, EventArgs e)
            {
                if (!_nextStateShoulBeVisible)
                {
    				Global.Instance.PullState();
    				_nextStateShoulBeVisible = true;
                }
            }
    
            // ******************************************************************
    
        }
    }
