    var linesWithUser = File.ReadLines(filePath).Where(x => x.Contains(user)).ToList();
 
    //Prints the count
    Console.WriteLine(linesWithUser.Count);
    //Prints all the lines that contain the user, maybe do other things...
    foreach(var line in linesWithUser)
    {
        Console.WriteLine(line);
    }
