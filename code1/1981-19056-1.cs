    // Consider this code public domain. If you want, you can even tell
    // your boss, attractive women, or the other guy in your cube that
    // you wrote it. Enjoy!
    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Drawing;
    
    namespace Utilities
    {
        public class RestorableForm : Form, INotifyPropertyChanged
        {
            // We invoke this event when the binding needs to be updated.
            public event PropertyChangedEventHandler PropertyChanged;
    
            // This stores the last window position and state
            private WindowRestoreStateInfo windowRestoreState;
    
            // Now we define the property that we will bind to our settings.
            [Browsable(false)]        // Don't show it in the Properties list
            [SettingsBindable(true)]  // But do enable binding to settings
            public WindowRestoreStateInfo WindowRestoreState
            {
                get { return windowRestoreState; }
                set
                {
                    windowRestoreState = value;
                    if (PropertyChanged != null)
                    {
                        // If anybody's listening, let them know the
                        // binding needs to be updated:
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("WindowRestoreState"));
                    }
                }
            }
    
            protected override void OnClosing(CancelEventArgs e)
            {
                WindowRestoreState = new WindowRestoreStateInfo();
                WindowRestoreState.Bounds
                    = WindowState == FormWindowState.Normal ?
                      Bounds : RestoreBounds;
                WindowRestoreState.WindowState = WindowState;
    
                base.OnClosing(e);
            }
            
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                
                if (WindowRestoreState != null)
                {
                    Bounds = ConstrainToScreen(WindowRestoreState.Bounds);
                    WindowState = WindowRestoreState.WindowState;
                }
            }
    
            // This helper class stores both position and state.
            // That way, we only have to set one binding.
            public class WindowRestoreStateInfo
            {
                Rectangle bounds;
                public Rectangle Bounds
                {
                    get { return bounds; }
                    set { bounds = value; }
                }
    
                FormWindowState windowState;
                public FormWindowState WindowState
                {
                    get { return windowState; }
                    set { windowState = value; }
                }
            }
    
            private Rectangle ConstrainToScreen(Rectangle bounds)
            {
                Screen screen = Screen.FromRectangle(WindowRestoreState.Bounds);
                Rectangle workingArea = screen.WorkingArea;
    
                int width = Math.Min(bounds.Width, workingArea.Width);
                int height = Math.Min(bounds.Height, workingArea.Height);
    
                // mmm....minimax
                int left = Math.Min(workingArea.Right - width,
                                    Math.Max(bounds.Left, workingArea.Left));
                int top = Math.Min(workingArea.Bottom - height,
                                    Math.Max(bounds.Top, workingArea.Top));
    
                return new Rectangle(left, top, width, height);
            }
        }
    }
