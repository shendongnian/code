        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Collections;
        using System.Collections.Generic;
        namespace Collections
        {
            class Program
            {
                static void Main(string[] args)
                {
                    ArrayList ar = new ArrayList();
                    object[] o = new object[3];
                    // Add 10 items to arraylist
                    for (int i = 0; i < 10; i++)
                    {
                        // Create some sample data to add to array of objects of different types.
                        Random r = new Random();
                        o[0] = r.Next(1, 100);
                        o[1] = "a" + r.Next(1,100).ToString();
                        o[2] = r.Next(1,100);
                        ar.Add(o);
                    }
                }
            }
        }
