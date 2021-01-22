            string txt = "Lore ipsum {{abc|prop1=\"asd\";prop2=\"bcd\";prop3=\"bbb\";}} asd lore ipsum";            
            Regex r = new Regex("{{(?<single>([a-z0-9]*))\\|((?<pair>((?<key>([a-z0-9]*))=\"(?<value>([a-z0-9]*))\";))*)}}", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Match m = r.Match(txt);            
            if (m.Success)
            {
                Console.WriteLine(m.Groups["single"].Value);
                foreach (Capture cap in m.Groups["pair"].Captures)
                {
                    Console.WriteLine(cap.Value);                    
                }
                foreach (Capture cap in m.Groups["key"].Captures)
                {
                    Console.WriteLine(cap.Value);
                }
                foreach (Capture cap in m.Groups["value"].Captures)
                {
                    Console.WriteLine(cap.Value);
                }
            }
