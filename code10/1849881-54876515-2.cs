    public class KeyboardStatusService
    {
    
        public delegate void KeyboardStatusChangeEventHandler(KeyboardStatusChangeEventArgs e);
        public event KeyboardStatusChangeEventHandler KeyboardStatusChangeEvent;
      
        private int _openHeightDelta = -1;
        private int _closedHeightDelta = -1;
    
        private InputMethodManager __imm = null;
        private InputMethodManager _imm
        {
            get
            {
                if (__imm == null || __imm.Handle == IntPtr.Zero)
                    __imm = BaseApplication.CurrentActivity?.GetSystemService(Context.InputMethodService) as InputMethodManager;
                return __imm;
            }
        }
    
    
        public KeyboardStatus Status { get; private set; } = KeyboardStatus.Closed;  // Default to closed when the app starts
    
        public bool Subscribed { get; private set; } = false;
        // Threshold used to remove false positives
        public int Threshold { get; set; } = 50;    
    
        public void Subscribe()
        {
            Subscribe(BaseApplication.CurrentActivity);
        }
    
        public void Subscribe(Activity activity)
        {
            if (!Subscribed)
            {
                var rootLayout = activity?.Window.DecorView; //.FindViewById(global::Android.Resource.Id.Content);
                if (rootLayout != null)
                {
                    // Subscribe to ViewTreeObserver.GlobalLayout
                    rootLayout.ViewTreeObserver.GlobalLayout += LayoutChangeDetected;
                    Subscribed = true;  // so we only ever subscribe once
                }
            }
        }
    
        private async void LayoutChangeDetected(object sender, EventArgs e)
        {
            await Task.Run(() => { LayoutChangeDetected(); }).ConfigureAwait(false);
        }
      
    
        private void LayoutChangeDetected()
        {
            var open = _imm.IsAcceptingText;
            if (Status == KeyboardStatus.Closed && open)  // was closed. now open
            {
                var rootLayout = BaseApplication.CurrentActivity.Window.DecorView;
                Rect r = new Rect();
                rootLayout.GetWindowVisibleDisplayFrame(r);
                Rect r1 = new Rect();
                rootLayout.GetLocalVisibleRect(r1);
                var heightDelta = r1.Bottom - r.Bottom;
                if (_openHeightDelta == -1)
                    _openHeightDelta = heightDelta;
    
                // Double check (in case we have manually changed layouts in response to the keyboard opening and closing
                if (heightDelta > _closedHeightDelta + Threshold)  // may need to add padding here to account for other layout changes
                {
                    Status = KeyboardStatus.Open;
                    // Trigger the event
                    KeyboardStatusChangeEvent?.Invoke(new KeyboardStatusChangeEventArgs(Status, _openHeightDelta));
                }
    
            }
            else if (Status == KeyboardStatus.Open)
            {
                if (!open)  // was open. now closed -  this handles when an action results in EditText losing focus and input ability
                {
                    Status = KeyboardStatus.Closed;
                    // Trigger the event
                    KeyboardStatusChangeEvent?.Invoke(new KeyboardStatusChangeEventArgs(Status, _closedHeightDelta));
                }
                else
                {
                    // some actions don't result in edit Text losing focus or input ability, such as keyboard dismiss button.
                    // This may be limited to when a hardware keyboard is attached, such as when debugging
                    var rootLayout = BaseApplication.CurrentActivity.Window.DecorView;
                    Rect r = new Rect();
                    rootLayout.GetWindowVisibleDisplayFrame(r);
                    Rect r1 = new Rect();
                    rootLayout.GetLocalVisibleRect(r1);
                    var heightDelta = r1.Bottom - r.Bottom;
                    if  (heightDelta < _openHeightDelta - Threshold)  // may need to add padding here to account for other layout changes
                    {
                        _closedHeightDelta = heightDelta;
                        Status = KeyboardStatus.Closed;
                        // Trigger the event
                        KeyboardStatusChangeEvent?.Invoke(new KeyboardStatusChangeEventArgs(Status, _closedHeightDelta));
                    }
                }
            }
        }
      
    
        public void Unsubscribe()
        {
            Unsubscribe(BaseApplication.CurrentActivity);
        }
        public void Unsubscribe(Activity activity)
        {
            var rootLayout = activity?.Window.DecorView; //.FindViewById(global::Android.Resource.Id.Content);
            if (rootLayout != null)
            {
                rootLayout.ViewTreeObserver.GlobalLayout -= LayoutChangeDetected;  // Don't need to check for subscribed as wont cause an issue
                Subscribed = false;
            }
        }
    
    
        public static void DismissKeyboard(Activity activity, View view)
        {
            if (view == null)
                view = new View(activity);
            InputMethodManager iMM = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
            iMM.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
            view.ClearFocus();
        }
        public static void DismissKeyboard(Context ctx, View view)
        {
            if (view == null)
                view = new View(ctx);
            InputMethodManager iMM = (InputMethodManager)ctx.GetSystemService(Context.InputMethodService);
            iMM.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
            view.ClearFocus();
        }
        public static void DismissKeyboard(Context ctx, Fragment fragment)
        {
            var view = fragment.View.RootView;
            InputMethodManager iMM = (InputMethodManager)ctx.GetSystemService(Context.InputMethodService);
            iMM.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
            view.ClearFocus();
        }
        public static void DismissKeyboard(Context ctx, global::Android.Support.V4.App.Fragment fragment)
        {
            var view = fragment.View.RootView;
            InputMethodManager iMM = (InputMethodManager)ctx.GetSystemService(Context.InputMethodService);
            iMM.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
            view.ClearFocus();
        }
        public static void DismissKeyboard(Fragment fragment)
        {
            var view = fragment.View.RootView;
            InputMethodManager iMM = (InputMethodManager)fragment.Activity.GetSystemService(Context.InputMethodService);
            iMM.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
            view.ClearFocus();
        }
        public static void DismissKeyboard(global::Android.Support.V4.App.Fragment fragment)
        {
            var view = fragment.View.RootView;
            InputMethodManager iMM = (InputMethodManager)fragment.Activity.GetSystemService(Context.InputMethodService);
            iMM.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
            view.ClearFocus();
        }
        public static void DismissKeyboard(Activity activity)
        {
            var view = activity.FindViewById(global::Android.Resource.Id.Content).RootView;
            InputMethodManager iMM = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
            iMM.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
            view.ClearFocus();
        }
        public static void ToggleKeyboard(Activity activity)
        {
            InputMethodManager iMM = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
            iMM.ToggleSoftInput(ShowFlags.Implicit, HideSoftInputFlags.ImplicitOnly);
        }
        public static void ShowKeyboard(Activity activity, View view, bool forced = false)
        {
            if (view == null)
                view = new View(activity);
            InputMethodManager iMM = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
            if (forced)
                iMM.ShowSoftInput(view, ShowFlags.Forced);
            else
                iMM.ShowSoftInput(view, ShowFlags.Implicit);
        }
        public static void ShowKeyboard(Context ctx, View view, bool forced = false)
        {
            if (view == null)
                view = new View(ctx);
            InputMethodManager iMM = (InputMethodManager)ctx.GetSystemService(Context.InputMethodService);
            if (forced)
                iMM.ShowSoftInput(view, ShowFlags.Forced);
            else
                iMM.ShowSoftInput(view, ShowFlags.Implicit);
        }
    
    }
    
    public enum KeyboardStatus
    {
        Closed,
        Open,
        Unknown
    }
    
    public class KeyboardStatusChangeEventArgs : EventArgs
    {
        public KeyboardStatus Status { get; private set; } = KeyboardStatus.Unknown;
        public int VisibleHeightToDecorHeightDelta { get; private set; } = -1;
        public KeyboardStatusChangeEventArgs(KeyboardStatus status, int visibleHeightToDecorHeightDelta)
        {
            Status = status;
            VisibleHeightToDecorHeightDelta = visibleHeightToDecorHeightDelta;
        }
    }
