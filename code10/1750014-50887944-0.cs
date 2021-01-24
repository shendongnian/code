        public void ControlClear(Control.ControlCollection controls, Type type)
        {
            foreach (Control c in controls)
                if (c.GetType() == type && c.GetType().GetMethod("Clear") != null)
                        c.GetType().InvokeMember("Clear", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, c, null);
        }
