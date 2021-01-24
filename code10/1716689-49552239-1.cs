    string[] linesc = File.ReadAllText(path).Split(Environment.NewLine);
    // extract global infos
    string[] name = linesc[0].Split(':');
    string[] age = linesc[1].Split(':');
    string[] location = linesc[2].Split(':');
    
    for (int i=3; i<linesc.Length; i++)
    {
        // reconcatenate new line
        string new2 = name[1] + "-" + age[1] + "-" + location[1] + "," + linesc[i];
        File.AppendAllText(path2 + "myfile.txt", new2 + Environment.NewLine);
    }
