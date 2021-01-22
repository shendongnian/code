    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace data_seniens
    {
        class Program
        {
            static void Main(string[] args)
            {
                //new list
                float [] x=new float[]{11.25f,18.0f,20.0f,10.75f,9.50f, 11.25f, 18.0f, 20.0f, 10.75f, 9.50f };
                
                //variable
                float eat_sleep_area=x[1]+x[3];
                //print
                foreach (var VARIABLE in x)
                {
                    if (VARIABLE < x[7])
                    {
                        Console.WriteLine(VARIABLE);
                    }
                }
                
              
    
                //keep app run
            Console.ReadLine();
            }
        }
    }
