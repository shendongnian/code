    Console.WriteLine(lines[0]); // This will print "Serial Number = 1"
    string[] slitLine = lines[0].Split('=');
    Console.WriteLine(slitLine[0]); //This will print "Serial Number"
    Console.WriteLine(slitLine[1]); //This will print 1, this is what you need to store in tb_SerialNo.Text, right?
----------
