        public void MaximizeForm(IntPtr handle)
        {
            Control c = Control.FromHandle(handle);
            Form c_form = c as Form;
            if (c_form != null)
            {
                if (c_form.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(delegate() { MaximizeForm(handle); }));
                }
                else
                {
                    c_form.WindowState = FormWindowState.Maximized;
                }
            }
        }
