                string tst = "some_function(type<whatever> tesxt_112,type<whatever> tesxt_113){";
            Regex r = new Regex(".*\\((.*)\\)");
            Match m = r.Match(tst);
            if (m.Success)
            {
                string[] arguments = m.Groups[1].Value.Split(',');
                for (int i = 0; i < arguments.Length; i++)
                {
                    Console.WriteLine("Argument " + (i + 1) + " = " + arguments[i]);
                }
            }
            Console.ReadKey();
