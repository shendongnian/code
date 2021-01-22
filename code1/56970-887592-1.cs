        int yourInteger;
        string newItem;
        newItem = textBox1.Text.Trim();
        Int32 num = 0;
        if ( Int32.TryParse(textBox1.Text, out num))
        {
            listBox1.Items.Add(newItem);
        }
        else
        {
            customValidator.IsValid = false;
            customValidator.Text = "You have not specified a correct number";
        }
