    using System.Collections.Generic;
    using System.Diagnostics;
    
     Random rnd = new Random();
            private void GetRandoms(int lowNumber, int highNumber, int numberOfItems)
            {
                List<int> sequence = new List<int>();
                for (int i = 0; i < numberOfItems; i++)
                {
                    sequence.Add(rnd.Next(lowNumber, highNumber + 1));
                }
                foreach (int i in sequence)
                {
                    Debug.Print(i.ToString());
                }
            }
