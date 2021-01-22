        private delegate void del();
        ....
        screenMain.Dispatcher.Invoke(new del(delegate()
        {
            screenMain.ButtonSubmit.IsEnabled = true;
            screenMain.ButtonPreClearing.IsEnabled = true;
        }));   
