        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Brush btnBrush = btn.Background;
            string color = "";
            if (btnBrush is SolidColorBrush)
            {
                color = ((SolidColorBrush)btnBrush).Color.ToString();
            }
            if (color ==  Brushes.Red.ToString())
            {
               //your logic of incrementing counter
            }
            else
            {
               //your logic of resting counter
            }
        }
