    class CarClass()
    {
      List<string> Cars = new List <string>();
    
      private void Button_Click(object sender, RoutedEventArgs e)
      {
        string colour = txtInput.Text;
        Cars.Add(colour);
        lstDisplay.Items.Add(colour);
      }
    }
