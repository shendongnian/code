    string line;
    using (StreamReader file = new StreamReader(@"db.txt"))
    {
        while ((line = file.ReadLine()) != null)
        {
            var values = line.Split(",");
            if (values[0] == "1713")
            {
                label1.Text = values[2];
            }
        }
    }
