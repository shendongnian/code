    class TestWindow
    {
        public TestWindow(RoutedEventHandler ButtonClickHandler)
        {
            SomeButton.Click += ButtonClickHandler;
        }
    }
    class Caller
    {
        void Test()
        {
            TestWindow A = new TestWindow((S, E) => {
                // Event Handler Codes ...
            });
            TestWindow B = new TestWindow(ClickHandler);
        }
        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            // Event Handler Codes ...
        }
    }
