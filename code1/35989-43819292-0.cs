     person p = new person();
                Action<int, int> mydel = p.add;       /*(int a, int b) => { Console.WriteLine(a + b); };*/
                Func<string, string> mydel1 = p.conc; /*(string s) => { return "hello" + s; };*/
               mydel(2, 3);
              string s1=  mydel1(" Akhil");
                Console.WriteLine(s1);
                Console.ReadLine();
