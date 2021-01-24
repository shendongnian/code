    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int between = 1;
        Random rnd = new Random();
    
        //This loop is pointless since there's only one number that can use it.
        //However; I've left it as it incase you're needing it for another reason.
        for (int i = 0; i < 10; i++)
        {
            if (between == 1)
            {
                int num1 = rnd.Next(1, 11); // 1-10
                int num2 = rnd.Next(1, 11); // 1-10
                string number1 = num1.ToString();
                string number2 = num2.ToString();
                kusimus.Text = number1 + " + " + number2;
            }
        }
    }
