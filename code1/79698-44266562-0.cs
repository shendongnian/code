        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt1.Text = Regex.Replace(txt1.Text, "[^0-9]+", "");
        }
 
 
