    dud.ValueChanged += DoubleUpDown_ValueChanged;
    private void DoubleUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
         if(e != null && Math.Abs((double)e.NewValue) < 0.000000001d)
         {
            // for example
         }
          
    }
