        int result = 0; // declare a private variable to hold the result
        
        // Event handler for Click of Enter button
        private void Enter_Click(object sender, EventArgs e)
        {
            result = Add(10,20);  // set result to result of some function like Add
            label.Text = result.ToString();
        }
        private int Add(int a, int b)
        {
            return a + b;
        }
