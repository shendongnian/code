     while ((line = reader.ReadLine()) != null)
        {
            if (!regex.IsMatch(line))
            {
                HeaderParse.Add(line);
            }
            else
            {
              //stop it adding stuff here
              break; 
            }
        }
