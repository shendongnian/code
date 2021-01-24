dict[key].Contactsp[j][dict[key].number++] = value;
            if (Contactsp.Count > j)
            {
                //as we should not be doing ++ multiple times
                int secondIndex = dict[key].number; 
                if (Contactsp[j].Count > secondIndex)
                {
                    Contactsp[j][secondIndex] = value;
                }
                else
                    Contactsp[j].Add(value);
            }
            else
            {
                Contactsp.Add(new List<string>());
                Contactsp[Contactsp.Count - 1].Add(value);
            }
            dict[key].number++;
