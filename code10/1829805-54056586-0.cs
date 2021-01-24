    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApp3
    {
        class Program
        {
            private static Random random = new Random();
            public static string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
    
    
            static void Main(string[] args)
            {
    
    
                Console.WriteLine("How many characters in the password?");
                string delta = Console.ReadLine();
    
                try
                {
                    int passwordlength = Convert.ToInt32(delta);
    
                    // BARRIER
    
                    string password = RandomString(passwordlength);
    
                    Random r = new Random();
                    string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    List<string> dictionary = new List<string>(new string[] { password });
    
                    string word = dictionary[r.Next(dictionary.Count)];
                    List<int> indexes = new List<int>();
                    Console.ForegroundColor = ConsoleColor.Red;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < word.Length; i++)
                    {
                        sb.Append(letters[r.Next(letters.Length)]);
                        if (sb[i] != word[i])
                        {
                            indexes.Add(i);
    
                        }
                    }
                    Console.WriteLine(sb.ToString());
    
                    var charsToGuessByIndex = indexes.ToDictionary(k => k, v => letters);
                    for (int i = indexes.Count - 1; i >= 0; i--)
                    {
                        while (indexes.Contains(i))
                        {
                            int index;
    
                            Thread.Sleep(50);
                            Console.Clear();
    
    
                            index = indexes[i];
    
                            var charsToGuess = charsToGuessByIndex[index];
                            sb[index] = charsToGuess[r.Next(charsToGuess.Length)];
    
                            charsToGuessByIndex[index] = charsToGuess.Remove(charsToGuess.IndexOf(sb[index]), 1);
                            if (sb[index] == word[index])
                            {
                                indexes.RemoveAt(i);
                            }
                            var output = sb.ToString();
    
                            for (int ii = 0; ii < output.Length; ii++)
                            {
                                if (indexes.Contains(ii))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
    
                                Console.Write(output[ii]);
                            }
    
                            Console.WriteLine();
                        }
                    }
    
                    Console.ForegroundColor = ConsoleColor.Green;
    
                    Console.WriteLine("Password successfully breached. Have a nice day.");
                    Console.WriteLine("");
    
                    Console.ReadLine();
                }
                catch
                {
                    if (delta is string)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("FATAL ERROR PRESS ENTER TO EXIT");
    
    
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("welp, it was worth a try.");
                        Console.ReadLine();
                    }
                }
            }
    
    
    
    
        }
    }
