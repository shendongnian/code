    int mostCommom = array[0];
                int occurences = 0;
                foreach (int num in array)
                {
                    if (!hs.ContainsKey(num))
                    {
                        hs.Add(num, 1);
                    }
                    else
                    {
                        int tempOccurences = (int)hs[num];
                        tempOccurences++;
                        hs.Remove(num);
                        hs.Add(num, tempOccurences);
     
                        if (occurences < tempOccurences)
                        {
                            occurences = tempOccurences;
                            mostCommom = num;
                        }
                    }
                }
                foreach (DictionaryEntry entry in hs)
                {
                    Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
                }
                Console.WriteLine("The commmon numer is " + mostCommom + " And it appears " + occurences + " times");
