    string a="bob, jon,man; francis;luke; lee bob";
    			String pattern = @"[,;\s]";
                String[] elements = Regex.Split(a, pattern).Where(item=>!String.IsNullOrEmpty(item)).Select(item=>item.Trim()).ToArray();;			
                foreach (string item in elements){
                    Console.WriteLine(item.Trim());
