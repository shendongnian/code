        private void RecursiveClickSubscribe(Control c)
        {
            if (c is Button)
            {
                c.Click += GenericClickHandler;
            }
            foreach (Control child in c.Controls)
            {
                RecursiveClickSubscribe(child);
            }
        }
        private void GenericClickHandler(object sender, EventArgs e)
        {
            // stuff you want to do on every click
        }
        Form myForm; // one of your three forms.
        RecursiveClickSubscribe(MyForm);
