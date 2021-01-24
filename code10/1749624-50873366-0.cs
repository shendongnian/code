    using System.IO;
    using System;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
            string input = "<aaa+aaa<aaa+aaa><aaa+aaa>><aaa+aaa>";
            
            int countOpenings = 0;
            
            // we use a StringBuilder because strings are immutable
            StringBuilder sb = new StringBuilder(input);
            
            for(int i = 0; i < sb.Length; i++)
            {
                // everytime we encounter '<', it's a new opening
                if(sb[i] == '<')
                {
                    countOpenings++;
                    // if it's the first opening, we change it to '{'
                    if(countOpenings == 1)
                    {
                        sb[i] = '{';
                    }
                }
                // everytime we encounter '>' it means we get out of a block
                else if(sb[i] == '>')
                {
                    countOpenings--;
                    // if the '>' matches the first opening, we change it to '}'
                    if(countOpenings == 0)
                    {
                        sb[i] = '}';
                    }
                }
                else if(sb[i] == '+' && countOpenings == 1)
                {
                    sb[i] = '=';
                }
            }
            
            Console.WriteLine(sb.ToString());
        }
    }
