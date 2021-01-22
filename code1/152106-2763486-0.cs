        void Background_Method(object sender, DoWorkEventArgs e)
        {
            // Time Consuming operations without using UI elements
            // Result of timeconsuming operations
            var result = new object();
            App.Current.Dispatcher.Invoke(new Action<object>((res) =>
                {
                    // Working with UI
                    TreeView tv = new TreeView();
                }), result);
        }
