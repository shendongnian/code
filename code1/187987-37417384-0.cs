    public partial class MeasureModalDialog : Window
    {
        //  Dialog has "Select area" button, need special launch mechanism. (showDialog / SwitchParentChildWindows)
        public static MeasureModalDialog instance = null;
        public static object parent = null;
        static public void showDialog(object _parent)
        {
            parent = _parent;
            if (instance == null)
            {
                instance = new MeasureModalDialog();
                // Parent is winforms, child is xaml, this is just glue to get correct window owner to child dialog.
                if (parent != null && parent is System.Windows.Forms.IWin32Window)
                    new System.Windows.Interop.WindowInteropHelper(instance).Owner = (parent as System.Windows.Forms.IWin32Window).Handle;
                // Enable parent window if it was disabled.
                instance.Closed += (_sender, _e) => { instance.SwitchParentChildWindows(true); };
                instance.ShowDialog();
                
                instance = null;
                parent = null;
            }
            else
            {
                // Try to switch to child dialog.
                instance.SwitchParentChildWindows(false);
            }
        } //showDialog
        public void SwitchParentChildWindows( bool bParentActive )
        {
            View3d.SwitchParentChildWindows(bParentActive, parent, this);
        }
        public void AreaSelected( String selectedAreaInfo )
        {
            if( selectedAreaInfo != null )     // Not cancelled
                textAreaInfo.Text = selectedAreaInfo;
            SwitchParentChildWindows(false);
        }
        private void buttonAreaSelect_Click(object sender, RoutedEventArgs e)
        {
            SwitchParentChildWindows(true);
            View3d.SelectArea(AreaSelected);
        }
        ...
    public static class View3d
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
        
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowEnabled(IntPtr hWnd);
        
        /// <summary>
        /// Extracts window handle in technology independent wise.
        /// </summary>
        /// <param name="formOrWindow">form or window</param>
        /// <returns>window handle</returns>
        static public IntPtr getHandle( object formOrWindow )
        {
            System.Windows.Window window = formOrWindow as System.Windows.Window;
            if( window != null )
                return new System.Windows.Interop.WindowInteropHelper(window).Handle;
            System.Windows.Forms.IWin32Window form = formOrWindow as System.Windows.Forms.IWin32Window;
            if (form != null)
                return form.Handle;
            return IntPtr.Zero;
        }
        
        /// <summary>
        /// Switches between modal sub dialog and parent form, when sub dialog does not needs to be destroyed (e.g. selecting 
        /// something from parent form)
        /// </summary>
        /// <param name="bParentActive">true to set parent form active, false - child dialog.</param>
        /// <param name="parent">parent form or window</param>
        /// <param name="dlg">sub dialog form or window</param>
        static public void SwitchParentChildWindows(bool bParentActive, object parent, object dlg)
        {
            if( parent == null || dlg == null )
                return;
            
            IntPtr hParent = getHandle(parent);
            IntPtr hDlg = getHandle(dlg);
            if( !bParentActive )
            {
                //
                // Prevent recursive loops which can be triggered from UI. (Main form => sub dialog => select (sub dialog hidden) => sub dialog in again.
                // We try to end measuring here - if parent window becomes inactive - 
                // means that we returned to dialog from where we launched measuring. Meaning nothing special needs to be done.
                //
                bool bEnabled = IsWindowEnabled(hParent);
                View3d.EndMeasuring(true);   // Potentially can trigger SwitchParentChildWindows(false,...) call.
                bool bEnabled2 = IsWindowEnabled(hParent);
                if( bEnabled != bEnabled2 )
                    return;
            }
            
            if( bParentActive )
            {
                EnableWindow(hDlg, false);      // Disable so won't eat parent keyboard presses.
                ShowWindow(hDlg, 0);  //SW_HIDE
            }
            EnableWindow(hParent, bParentActive);
            
            if( bParentActive )
            {
                SetForegroundWindow(hParent);
                BringWindowToTop(hParent);
            } else {
                ShowWindow(hDlg, 5 );  //SW_SHOW
                EnableWindow(hDlg, true);
                SetForegroundWindow(hDlg);
            }
        } //SwitchParentChildWindows
        ...
