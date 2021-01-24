    for (int i = 0; i < nummer.Length; i++)
            {
                try { 
                Console.Write("Nummer " + talnr + ": ");
                talnr++;
                string str = Console.ReadLine();
                int element = Convert.ToInt32(str);
                nummer[i] = element;
                }
                catch
                {
                    MessageBox.Show("Error, numbers only");
                    goto breakloop;
                }
            }
            breakloop:;
