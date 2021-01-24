    string line = string.Empty;
    //lines used to store the lines read from the file
    List<string> lines = new List<string>();
    //path used to store the path of the file 
    string path = @"c:\Name.txt";
    //check whether file exists or not
    if (File.Exists(path)) {
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        //read the line from file
        while ((line = file.ReadLine()) != null) {
            //check whether line is equal to the searched word
            if (line == "David") { // Give your search term here!
                lines.Add("\"find my word\"");
            }
            //add the line to lines string list
            lines.Add(line);
        }
        //close the file
        file.Close();
    }  
    //write all the lines stored in lines to the file
    File.WriteAllLines(path, lines);
