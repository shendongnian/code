    private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string text;
        FileStream aFile = new FileStream("D:\\PhoneBook.txt", FileMode.Open);
        StreamReader sr = new StreamReader(aFile);
        text = sr.ReadLine();
        // Read data in line by line.
        while (text != null)
        {
            foreach (string info in text.Split(',')) 
            {
                listView1.Items.Add(info);
            }        
            // read the next line here
            text = sr.ReadLine();      
        }
        
        sr.Close();
    }
