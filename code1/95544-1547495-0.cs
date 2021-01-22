            //Constructing string...
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("first line");
            sb.AppendLine("second line");
            sb.AppendLine("third line");
            string s = sb.ToString();
            Console.WriteLine(s);
            //splitting multiline string into separate lines
            string[] splitted = s.Split(new string[] {System.Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            // output (separate lines)
            for( int i = 0; i < splitted.Count(); i++ )
            {
                Console.WriteLine("{0}: {1}", i, splitted[i]);
            }
