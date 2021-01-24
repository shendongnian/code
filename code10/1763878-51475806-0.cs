        public void BtnCompute_Click_1(object sender, RoutedEventArgs e)
        {
            MyClass ff = new MyClass();
            int amount;
            int.TryParse(ff.SelectedAmount, out amount);
            deposit = amount;
        }
