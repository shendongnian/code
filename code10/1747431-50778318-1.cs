    private void Calculate()
    {
        if(!double.TryParse(textBox1.Text, out num))
           return;
        for (int a = 1; a <= 10; a++)
        {
            listBox1.Items.Add(a + " * " + num + "\n = " + a * num);
        }
    }
