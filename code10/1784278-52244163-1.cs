        Dashboard.xaml
        private void DoAnimate(Object sender, EventArgs e)
        { 
            ThicknessAnimation anima =
            new ThicknessAnimation(new Thickness(0), new Thickness(150, 0, 0, 0),
            new Duration(new TimeSpan(0, 0, 1)), FillBehavior.HoldEnd);
            anima.From = new Thickness(150, 0, 0, 0);
            anima.To = new Thickness(100, 0, 0, 0);
            anima.AutoReverse = false;
            // page is the name of the grid that gets animated.
            page.BeginAnimation(Border.MarginProperty, anima);
        }
   
     private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           Menu.AnimateButtonClicked += new EventHandler(DoAnimate);
             
        }
 
