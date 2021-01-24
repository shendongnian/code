    for (int x = 0; x <= 1 ; x++) 
    {
       if (comboBox1.SelectedIndex == x) 
       {
            var stringArray = x==0 ? S0 : S1; // select array S0 or S1 dependent on value of X
            foreach (string items in stringArray)
            {
                 comboBox2.Items.Add(items);
            }
        }
    }
