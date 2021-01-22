        DateTime date = DateTime.MinValue;
        bool parseResult = DateTime.TryParse(textBox1.Text, out date);
        if(parseResult)
        {
            //parse was successful, continue
        }
