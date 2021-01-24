    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApp3
    {
        class Program
        {
            private static Random random = new Random();
            static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    
            public static string generatePassword(int length)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sb.Append(chars.OrderBy(o => Guid.NewGuid()).First());
                }
                return sb.ToString();
            }
    
            public static StringBuilder generateNotPassword(int length, string password)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sb.Append(chars.Where(w => password[i] != w).OrderBy(o => Guid.NewGuid()).First());
                }
                return sb;
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine("How many characters in the password?");
                var passwordlength = int.Parse(Console.ReadLine());
                var password = generatePassword(passwordlength);
                var notPassword = generateNotPassword(passwordlength, password);
    
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                for (int i = 0; i < passwordlength; i++)
                {
                    var notfound = true;
                    while (notfound)
                    {
    
                        foreach (var c in chars)
                        {
                            if (password[i] == c)
                            {
                                notPassword[i] = c;
                                notfound = false;
                            }
                            Thread.Sleep(50);
                            Console.Clear();
                            var output = notPassword.ToString();
                            for (int ii = 0; ii < output.Length; ii++)
                            {
                                var iii = (!notfound && i == ii) ? ii - 1 : ii;
                                Console.ForegroundColor = i > iii ? ConsoleColor.Red : ConsoleColor.Cyan;
                                var o = i <= iii ? '█' : output[ii];
                                Console.Write(o);
                            }
                            Console.WriteLine();
                            TimeSpan ts = stopWatch.Elapsed;
                            Console.WriteLine
                                (String.Format(
                               "RunTime {0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
                            if (!notfound) break;
                        }
    
    
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
    
                Console.WriteLine($"Guessed  Password = {notPassword}");
                Console.WriteLine($"Original Password = {password}");
                //https://www.asciiart.eu/electronics/electronics
                Console.WriteLine(@"
                                      ____
                                 ____|    \
                                (____|     `._____
                                 ____|       _|___
                                (____|     .'
                                     |____/
    
                                ");
                Console.ReadLine();
            }
        }
    }
