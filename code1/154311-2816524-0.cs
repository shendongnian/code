        private void MyTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt!=null)
             {
                Messagebox.Show("It works");
             }
            
        }
