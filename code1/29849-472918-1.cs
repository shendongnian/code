    string pi = "\u03a0";
    byte[] ascii = System.Text.Encoding.ASCII.GetBytes (pi);
    byte[] utf8 = System.Text.Encoding.UTF8.GetBytes (pi);
			
    Console.WriteLine (ascii.Length); //will print 1
    Console.WriteLine (utf8.Length); //will print 2
    Console.WriteLine (System.Text.Encoding.ASCII.GetString (ascii)); //will print '?'
