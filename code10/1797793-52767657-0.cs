    private float subTotal = 0;    // this would be a field in your class
    private void buttonOrder_Click(object sender, EventArgs e)
    {
      float num1, num2; 
      num1 = float.Parse(textPrice.Text); 
      num2 = float.Parse(textQuantity.Text); 
      subTotal += num1 * num2;
      
      textSubtotal.Text = subTotal;
    }
