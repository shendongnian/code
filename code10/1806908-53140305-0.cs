    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp20
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = @"&1 \&2 \\&3 \\\&4 \\  ";
                var s = str.Split(' ');
                StringBuilder sb = new StringBuilder();
                foreach (var item in s)
                {
                    var f = item.Split('\\');
    
                    if (f.Length % 2 == 0)
                    {
                        if (f.Length > 3)
                        {
                            sb.Append($@"\{f[f.Length - 1]}");
                        }
                        else
                        {
                            sb.Append(f[f.Length - 1]);
                        }
                    }
                    else
                    {
                        if (f.Length > 2)
                        {
                            sb.Append($@"\{f[f.Length - 1].Replace('&', '§')}");
                        }
                        else
                        {
                            sb.Append(f[f.Length - 1].Replace('&', '§'));
                        }
                    }
                    sb.Append("  ");
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
