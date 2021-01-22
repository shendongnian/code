      if(textToSplit!=null)
       {
        List<string> lines = new List<string>();
        using (StringReader reader = new StringReader(textToSplit))
        {
            for (string line = reader.ReadLine(); line != null;line = reader.ReadLine())
            {
                lines.Add(line);
            }
        }
       }
