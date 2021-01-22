    private int count = 0;
    private void button2_Click(object sender, EventArgs e)
    {
        ...
    
        if (int.Parse(textBox2.Text) == Magicnumber)
        { 
            // User wins
            ...
        }
        else
        { 
            // Wrong answer
            count++;
            ...
        }
    }
