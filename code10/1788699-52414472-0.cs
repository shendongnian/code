            using (var rdr = new StreamReader(fileName))
            using (var wrtrGood = new StreamWriter(goodRowFileName))
            using (var wrtrBad = new StreamWriter(badRowFileName))
            {
                string line = null;
                while ((line = rdr.ReadLine()) != null)
                {
                    if (line.Contains(charGood))
                    {
                        goodRow++;
                        wrtr.WriteLine(line);
                    }
                    else
                    {
                        badRow++;
                        wrtrBad.WriteLine(line);
                    }
                }
            }
