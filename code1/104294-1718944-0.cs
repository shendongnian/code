    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    class Timer : IDisposable
    {
        private DateTime _start;
        private string _name;
        public Timer(string name)
        {
            _name = name;
            _start = DateTime.Now;
        }
        public void Dispose()
        {
            TimeSpan taken = DateTime.Now - _start;
            Console.WriteLine(string.Format ("{0} : {1} seconds", _name, taken.TotalMilliseconds / 1000.0));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int reps = 5000000;
            string oldString = "200 abc def abc [a18943]";
            using (new Timer("LINQ"))
            {
                for (int n = 0; n < reps; n++)
                {
                    string[] a = oldString.Split(' ');
                    var result = a.Skip(a.Length - 1)
                                .Select(w => w.Replace("[", "").Replace("]", ""))
                                .Concat(a.Take(a.Length - 1).Skip(1)).ToArray();
                    var newString = string.Join(" ", result);
                }
            }
            using (new Timer("my Split + StringBuilder way"))
            {
                for (int n = 0; n < reps; n++)
                {
                    string[] words = oldString.Split(' ');
                    StringBuilder sb = new StringBuilder(words[words.Length - 1].Trim('[', ']'));
                    for (int i = 1; i < words.Length - 1; i++)
                    {
                        sb.Append(' ');
                        sb.Append(words[i]);
                    }
                    string newString = sb.ToString();
                }
            }
            using (new Timer("wipeck's Split-and-Join way!"))
            {
                for (int n = 0; n < reps; n++)
                {
                    string valueString = "200 abc def abc [a18943]";
                    string[] values = valueString.Split(' ');
                    string lastWord = values[values.Length - 1];
                    lastWord = lastWord.Trim('[', ']');
                    values[0] = lastWord;
                    string movedValueString = string.Join(" ", values, 0, values.Length - 1);
                }
            }
            using (new Timer("(uncompiled) regex"))
            {
                for (int n = 0; n < reps; n++)
                {
                    string newString = Regex.Replace(@"^(\w+)(.+) \[(\w+)\]$", oldString, "$3$2");
                }
            }
            Regex regex = new Regex(@"^(\w+)(.+) \[(\w+)\]$", RegexOptions.Compiled);
            string newStringPreload = regex.Replace(oldString, "$3$2");
            using (new Timer("(compiled) regex"))
            {
                for (int n = 0; n < reps; n++)
                {
                    string newString = regex.Replace(oldString, "$3$2");
                }
            }
        }
    }
