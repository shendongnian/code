        public void GenArray20_Click(object sender, RoutedEventArgs e)
        {
    		// You have local initilization of array
    		// so code inside this method will load data into this array instead of global
            //int[] arraytwenty = new int[20];
            Random Number = new Random();
    
            for (int i = 0; i < 20; i++)
            {
                int randomnum = Number.Next(1, 101);
                arraytwenty[i] = randomnum;
    
                Original20Array.Text = Original20Array.Text + " " + Convert.ToString(arraytwenty[i]);
            }
        }
