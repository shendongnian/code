    StringBuilder strbuild = new StringBuilder();
    using (StreamReader reader = new StreamReader("buf.txt", System.Text.Encoding.ASCII))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            switch (line[0])
            {
                case 'A':
                case 'a':
                    strbuild.Append(line);
                    break;
                case 'B':
                case 'b':
                    strbuild.Append("BET");
                    break;
            }
        }
    }
    MessageBox.Show(strbuild.ToString());
