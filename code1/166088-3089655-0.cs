       string keyword = "hello";
     
       foreach (char ch in keyword) {
          Console.Write("[" + ch + "]");
       }
       Console.WriteLine();
       // prints "[h][e][l][l][o]"
     
       StringBuilder sb = new StringBuilder();
       for (int i = 0; i < keyword.Length; i++) {
          sb.Append("<" + keyword[i] + ">");
       }
       Console.WriteLine(sb);
       // prints "<h><e><l><l><o>"
     
       Console.WriteLine(new Regex(@"(?=.)").Replace(keyword, @"/"));
       // prints "/h/e/l/l/o"
     
       Console.WriteLine(new Regex(@"(.)").Replace(keyword, @"($1$1)"));
       // prints "(hh)(ee)(ll)(ll)(oo)"
