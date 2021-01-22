                int x;
                double y;
                string spork = "-3.14";
                if (int.TryParse(spork, out x))
                    Console.WriteLine("Yay it's an int (boy)!");
                if (double.TryParse(spork, out y))
                    Console.WriteLine("Yay it's an double (girl)!");
