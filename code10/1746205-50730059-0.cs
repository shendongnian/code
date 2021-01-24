    using (StreamReader data = new StreamReader(path))
    {
    
        data.ReadLine();                                        //Header verwerfen
        gpsGGA.Clear();
        gpsRMC.Clear();
        int counter = 0;
        while (!data.EndOfStream)
        {
            string line = data.ReadLine();
            if (! String.IsNullOrEmpty(line))
            {
                string[] substring = line.Split(';');
                if ( substring.Length < 13 )
                     throw new ApplicationException("Malformated Data At Line " + counter.ToString());
                gpsGGA.Add(substring[11]);
                gpsRMC.Add(substring[12]);
            }
            counter += 1;
        }
    }
