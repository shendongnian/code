        public delegate void ClipboarDelegate();
        ClipboarDelegate clipboardDelegate = null;
        void clipboardTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (clipboardDelegate == null)
                clipboardDelegate = ClipboarDelegateMethod;
            //Here we get the right thread, most probably the application thread
            Application.Current.Dispatcher.BeginInvoke(clipboardDelegate);
        }
        public void ClipboarDelegateMethod()
        {
            try
            {
                if (Clipboard.ContainsData(DataFormats.Text))
                {
                    //It's important to lock this section
                    lock (ClipboardString)
                    {
                        ClipboardString = Clipboard.GetData(DataFormats.Text) as string;
                    }
                }
            }
            catch
            { }
        }
