    class MyWindow : Window
    {
        Button _button;
        int _numClicked = 0;
        
        public MyWindow()
        {
            this._button = new Button();
            // place the button in the window
            this._button.Click += this.ButtonClicked;
        }
    
        void ButtonClicked(object sender, RoutedEventArgs e)
        {
            this._numClicked += 1;
            MessageBox.Show("Button Clicked " + this._numClicked + " times");
        }
    }
