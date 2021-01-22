            //Using Regex. 
            Regex r = new Regex(@"\b[Tt]he\b");
            
            System.Diagnostics.Stopwatch stp = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                string str = "The man is old. The is the Good. Them is the bad.";
                str = r.Replace(str, "@@");
            }
            stp.Stop();
            Console.WriteLine(stp.Elapsed);
            //Using String Methods.
            stp = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                string str = "The man is old. The is the Good. Them is the bad.";
                //Remove the The if the stirng starts with The.
                if (str.StartsWith("The "))
                {
                    str = str.Remove(0, "The ".Length);
                    str = str.Insert(0, "@@ ");
                }
                //Remove references The and the.  We can probably 
                //assume a sentence will not end in the.
                str = str.Replace(" The ", " @@ ");
                str = str.Replace(" the ", " @@ ");
            }
            stp.Stop();
            Console.WriteLine(stp.Elapsed);
