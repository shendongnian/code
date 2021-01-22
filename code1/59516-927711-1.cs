        var c = new char[] { (char)149 };
        var b = System.Text.Encoding.Default.GetBytes(c);
        Console.WriteLine("{0}", (int)c[0]);  
        Console.WriteLine("{0}", (int) b[0]);
        
