                    dictionary.add(control, "string1");
                    dictionary.add(control, "string1");
                    dictionary.add(control, "string2");
                  int x = 0;
            for (int i = 0; i < dictionary.Count; i++)
            {         
                if (dictionary.ElementAt(i).Value == valu)
                {
                    x++;
                }
                if (x > 1)
                {
                    dictionary.Remove(control);
                }
            }
