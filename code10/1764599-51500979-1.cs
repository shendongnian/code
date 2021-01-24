    using System.Windows.Media;
    /*The rest of your code goes here*/
    private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var foo = sender as ComboBox;
            var bar = foo.SelectedItem as ComboBoxItem;
            switch (bar.Name)
            {
                case "GreenOption":
                    foo.Background = Brushes.Green;
                    break;
                case "PinkOption":
                    foo.Background = Brushes.Pink;
                    break;
                case "RedOption":
                    foo.Background = Brushes.Red;
                    break;
                case "BlueOption":
                    foo.Background = Brushes.Blue;
                    break;
            }
        }
    /* Or Here */
