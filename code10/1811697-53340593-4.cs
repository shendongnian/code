    int sum = 0;
    var message = new StringBuilder();
    var delimiter = "";
    for(int i = 0; i<cart.Length; i++)
    {
        if (cart[i])
        {
           sum += price[i];
           message.Append(delimiter).Append(goods[i]);
           delimiter = ",";
        }
    }
    MessageBox.Show($"{message}\nTotal: {sum}");
