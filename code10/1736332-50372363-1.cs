        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        namespace StrReader
        {
            class Program
            {
                static void Main(string[] args)
                {
                    bool hit = false;
                    string start = "?id=";
                    string end = "&amp;";
                    string buffer = string.Empty;
                    string endBuffer = string.Empty;
                    using(StreamReader sr = new StreamReader(@"C:\development\zaza.txt"))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string value = ((char)sr.Read()).ToString();
                            if(!hit){
                                if (start.IndexOf(value) > -1)
                                    buffer = string.Concat(buffer, value);
                                else buffer = string.Empty;
                                hit = string.Equals(buffer, start, StringComparison.CurrentCultureIgnoreCase);
                                if (buffer.Length >= start.Length && hit)
                                    buffer = string.Empty;
                            }
                            else
                            {
                                if (end.IndexOf(value) > -1)
                                    endBuffer = String.Concat(endBuffer, value);
                                else
                                    endBuffer = string.Empty;
                                buffer = string.Concat(buffer, value);
                                if (endBuffer == end)
                                {
                                    Console.WriteLine(buffer.Substring(0,buffer.Length - endBuffer.Length ));
                                    buffer = string.Empty;
                                    hit = false;
                                }
                                buffer = string.Concat(buffer, value);
                            }
                        }
                    }
                    Console.ReadLine();
                }
            }
        }
