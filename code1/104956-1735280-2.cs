    class MyWindow : Window
    {
        Button _button;
        int _numClicked = 0;
        
        public MyWindow(string localStringParam)
        {
            string localStringVar = "a local variable";
            this._button = new Button();
            // place the button in the window
            this._button.Click += new RoutedEventHandler(
                delegate(object sender, RoutedEventArgs args)
                {
                    this._numClicked += 1;
                    MessageBox.Show("Param was: " + localStringParam + 
                         " and local var " + localStringVar +
                         " button clicked " + this._numClicked + " times");
                });
        }
    }
