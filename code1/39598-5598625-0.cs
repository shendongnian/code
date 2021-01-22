    using System;
    using System.Windows.Interactivity;
    using System.Windows; // For Window in behavior
    using System.Windows.Interop; // For Hwnd
    public class WindowResizeEvents : Behavior<Window>
        {
            public event EventHandler Resized;
            public event EventHandler Resizing;
            public event EventHandler Maximized;
            public event EventHandler Minimized;
            public event EventHandler Restored;
    
            public static DependencyProperty IsAppAskCloseProperty =  DependencyProperty.RegisterAttached("IsAppAskClose", typeof(bool), typeof(WindowResizeEvents));
            public Boolean IsAppAskClose
            {
                get { return (Boolean)this.GetValue(IsAppAskCloseProperty); }
                set { this.SetValue(IsAppAskCloseProperty, value); }
            }
    
            // called when the behavior is attached
            // hook the wndproc
            protected override void OnAttached()
            {
                base.OnAttached();
    
                AssociatedObject.Loaded += (s, e) =>
                {
                    WireUpWndProc();
                };
            }
    
            // call when the behavior is detached
            // clean up our winproc hook
            protected override void OnDetaching()
            {
                RemoveWndProc();
    
                base.OnDetaching();
            }
    
            private HwndSourceHook _hook;
    
            private void WireUpWndProc()
            {
                HwndSource source = HwndSource.FromVisual(AssociatedObject) as HwndSource;
    
                if (source != null)
                {
                    _hook = new HwndSourceHook(WndProc);
                    source.AddHook(_hook);
                }
            }
    
            private void RemoveWndProc()
            {
                HwndSource source = HwndSource.FromVisual(AssociatedObject) as HwndSource;
    
                if (source != null)
                {
                    source.RemoveHook(_hook);
                }
            }
    
            private const Int32 WM_EXITSIZEMOVE = 0x0232;
            private const Int32 WM_SIZING = 0x0214;
            private const Int32 WM_SIZE = 0x0005;
    
            private const Int32 SIZE_RESTORED = 0x0000;
            private const Int32 SIZE_MINIMIZED = 0x0001;
            private const Int32 SIZE_MAXIMIZED = 0x0002;
            private const Int32 SIZE_MAXSHOW = 0x0003;
            private const Int32 SIZE_MAXHIDE = 0x0004;
    
            private const Int32 WM_QUERYENDSESSION = 0x0011;
            private const Int32 ENDSESSION_CLOSEAPP = 0x1;
            private const Int32 WM_ENDSESSION = 0x0016;
    
            private IntPtr WndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
            {
                IntPtr result = IntPtr.Zero;
    
                switch (msg)
                {
                    case WM_SIZING:             // sizing gets interactive resize
                        OnResizing();
                        break;
    
                    case WM_SIZE:               // size gets minimize/maximize as well as final size
                        {
                            int param = wParam.ToInt32();
    
                            switch (param)
                            {
                                case SIZE_RESTORED:
                                    OnRestored();
                                    break;
                                case SIZE_MINIMIZED:
                                    OnMinimized();
                                    break;
                                case SIZE_MAXIMIZED:
                                    OnMaximized();
                                    break;
                                case SIZE_MAXSHOW:
                                    break;
                                case SIZE_MAXHIDE:
                                    break;
                            }
                        }
                        break;
    
                    case WM_EXITSIZEMOVE:
                        OnResized();
                        break;
    
                    // Windows is requesting app to close.    
                    // See http://msdn.microsoft.com/en-us/library/windows/desktop/aa376890%28v=vs.85%29.aspx.
                    // Use the default response (yes).
                    case WM_QUERYENDSESSION:
                        IsAppAskClose = true; 
                        break;
                }
    
                return result;
            }
    
            private void OnResizing()
            {
                if (Resizing != null)
                    Resizing(AssociatedObject, EventArgs.Empty);
            }
    
            private void OnResized()
            {
                if (Resized != null)
                    Resized(AssociatedObject, EventArgs.Empty);
            }
    
            private void OnRestored()
            {
                if (Restored != null)
                    Restored(AssociatedObject, EventArgs.Empty);
            }
    
            private void OnMinimized()
            {
                if (Minimized != null)
                    Minimized(AssociatedObject, EventArgs.Empty);
            }
    
            private void OnMaximized()
            {
                if (Maximized != null)
                    Maximized(AssociatedObject, EventArgs.Empty);
            }
        }
    <Window x:Class="MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml
            xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
            xmlns:behaviors="clr-namespace:RapidCoreConfigurator._Behaviors"
            Title="name" Height="500" Width="750" BorderBrush="Transparent">
    
        <i:Interaction.Behaviors>
            <behaviors:WindowResizeEvents IsAppAskClose="{Binding IsRequestClose, Mode=OneWayToSource}"
                                          Resized="Window_Resized"
                                          Resizing="Window_Resizing" />
        </i:Interaction.Behaviors>
       
        ... 
        
    </Window>
