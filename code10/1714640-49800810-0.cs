        private void ShowWindowOrder_Click(object sender, EventArgs e)
        {
            var children = this.MdiChildren.ToList();
            var sb = new StringBuilder();
            foreach (var child in this.GetChildrenSortedByZOrder())
            {
                sb.AppendLine(child.Text);
            }
            MessageBox.Show(sb.ToString());
        }
        private delegate bool EnumChildProc(IntPtr hwnd, IntPtr lParam);
        [DllImport("User32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);
        private IEnumerable<Form> GetChildrenSortedByZOrder()
        {
            List<IntPtr> handles = new List<IntPtr>();
            if (IsHandleCreated)
            {
                EnumChildWindows(Handle,
                    (hWnd, lparam) =>
                    {
                        handles.Add(hWnd);
                        return true;
                    }, IntPtr.Zero);
            }
            List<Form> children = new List<Form>(handles.Count);
            foreach (IntPtr handle in handles)
            {
                Form form = FromHandle(handle) as Form;
                if (form != null)
                    children.Add(form);
            }
            return children;
        }
