        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = "012wxyz789";
            string NotNumbers = "";
            char[] arr;
            arr = str.ToCharArray();
            foreach (char c in arr)
            {
                int outValue;
                bool IsNumber = Int32.TryParse(c.ToString(), out outValue);
                if (IsNumber)
                {
                    // Do something to number
                }
                else
                {
                    // Do something to other
                    // Build a string with all the non number values
                    NotNumbers = NotNumbers + c.ToString();
                }
            }
        }
