        private delegate void NoArgDelegate();
        private static void Refresh(DependencyObject obj)
        {
            obj.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
                (NoArgDelegate)delegate { });
        }
        public void LogoUpdate(MainWindow w, string m)
        {
            w.TBox.Text = m;
            Refresh(w);
        }
