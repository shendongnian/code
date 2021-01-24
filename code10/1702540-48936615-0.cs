    private void button1_Click(object sender, EventArgs e)
    {
    
        List<string> price = new List<string>();
        using (StreamReader readFile = new StreamReader("price.txt"))
        {
            string line;
            while ((line = readFile.ReadLine()) != null)
            {
                price.Add(line);
                finalPrice.Items.Add(line);
            }
        }
    
        //Convert string to double, then sum all lines
        var sum = price.Select(s => Convert.ToDouble(s)).Sum();
    }
