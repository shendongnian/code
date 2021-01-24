     List<string> one = new List<string>();
            foreach (String string1 in LB1.Items)
            {
                one.Add(string1);
            }
            List<string> two = new List<string>();
            foreach (String string2 in LB2.Items)
            {
                two.Add(string2);
            }
                foreach (String string1 in one)
            {
                foreach (String string2 in two)
                {
                string    cat1 = string1.Substring(0, string1.Length - 4);
                  string  cat2 = string2.Substring(0, string2.Length - 5);
                    if (cat1.Equals(cat2))
                    {
                       LB1.Items.Remove(string1);
                        // if you want to stop after the first match, break; 
                        // else remove break to find all matches;
                        break;
                    }
                }
            }
