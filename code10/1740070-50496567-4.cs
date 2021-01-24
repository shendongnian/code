    public void OpenForms<T>(params object[] args) where T : Form
    {
        Form form = container_panel.Controls.OfType<T>().FirstOrDefault();
        if (form !=null)
        {
            //If the instance is minimized we leave it in its normal state
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            //If the instance exists, I put it in the foreground
            form.BringToFront();
            return;
        }
        if (args == null || args.Length == 0)
            form = Activator.CreateInstance<T>();
        else
            form = (T)Activator.CreateInstance(typeof(T), args);
        form.TopLevel = false;
        container_panel.Controls.Add(form);
        container_panel.Tag = form;
        form.Show();
    }
