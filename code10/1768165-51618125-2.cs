    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static void Main(string[] args)
                {
        
                    string one = "http://<site>/Non Archive/<document>";
                    string two = "http://<site>/Archive/<document>";
                    char delimiter = '/';
                    List<string> list = new List<string> { one, two };
                    string target = "Archive";
        
                    foreach (string s in list)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("after remove");
        
                    list.RemoveAll(x => x.Split(delimiter).ToList().Any(y => y.Equals(target)));
        
                    foreach (string s in list)
                    {
                        Console.WriteLine(s);
                    }
        
        
                    Console.ReadLine();
        
                }
