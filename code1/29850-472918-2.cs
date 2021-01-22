    string pi = "\u03a0";
    byte[] ascii = System.Text.Encoding.ASCII.GetBytes (pi);
    byte[] utf8 = System.Text.Encoding.UTF8.GetBytes (pi);
			
    Console.WriteLine (ascii.Length); //Will print 1
    Console.WriteLine (utf8.Length); //Will print 2
    Console.WriteLine (System.Text.Encoding.ASCII.GetString (ascii)); //Will print '?'
