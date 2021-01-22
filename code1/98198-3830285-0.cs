    public class FlickerFreeListView : ListView
    {
        #region Static Functionality
        private static FieldInfo _internalVirtualListSizeField;
        static FlickerFreeListView()
        {
            _internalVirtualListSizeField = typeof(ListView).GetField("virtualListSize", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance);
            
            if (_internalVirtualListSizeField == null)
            {
                string msg = "Private field virtualListSize in type System.Windows.Forms.ListView is not found. Workaround is incompatible with installed .NET Framework version, running without workaround.";
                Trace.WriteLine(msg);
            }
        }
        #endregion
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
        internal IntPtr SendMessage(int msg, IntPtr wparam, IntPtr lparam)
        {
            return SendMessage(new HandleRef(this, this.Handle), msg, wparam, lparam);
        }
        public void SetVirtualListSize(int size)
        {
            // if workaround incompatible with current framework version (usually MONO)
            if (_internalVirtualListSizeField == null)
            {
                VirtualListSize = size;
            }
            else
            {
                if (size < 0)
                {
                    throw new ArgumentException("ListViewVirtualListSizeInvalidArgument");
                }
                _internalVirtualListSizeField.SetValue(this, size);
                if ((base.IsHandleCreated && this.VirtualMode) && !base.DesignMode)
                {
                    SendMessage(0x102f, new IntPtr(size), new IntPtr(2));
                }
            }
        }
    }
