    protected void MathOps(object sender, EventArgs e)
    {
        //TODO: Simplification: we assume all TextBox1.Text..TextBox3.Text have valid values
        double[] arr = new double[] {
          double.Parse(TextBox1.Text), 
          double.Parse(TextBox2.Text),
          double.Parse(TextBox3.Text),  
        };
    
        double sum = 0;
        double product = 0;
        double average = 0;
    
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            product *= arr[i];
        }
    
        average = sum / arr.Length;
        //DONE: There's no need to output in each iteration
        TextBox6.Text = sum.ToString();
        TextBox7.Text = product.ToString();
        TextBox8.Text = average.ToString();
    }
