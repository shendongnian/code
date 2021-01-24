         string[] val = { "First", "Second", "Third", "Forth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth" };
            for (int i = 0,j=1;  i < val.Length  ; i++) {
                Console.Write("{0}   ", val[i]);
                if (j % 3 == 0)
                {
                    Console.WriteLine();
                }
                j++;
            }
            Console.ReadLine();
