dict[key].Contactsp[j][dict[key].number++] = value;
            if (Contactsp.Count > j)
            {
                if (Contactsp[j].Count > dict[key].number++)
                    Contactsp[j][dict[key].number++] = value;
                else
                    Contactsp[j].Add(value);
            }
            else
            {
                Contactsp.Add(new List<string>());
                Contactsp[Contactsp.Count].Add(value);
            }
