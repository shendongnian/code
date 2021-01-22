    // this variable maps the timestamps to complete lines
    var dict = new Dictionary<string, string>();
    // create the map of stamp => line for the original text file
    string fileLine = file.ReadLine();
    string fileStamp = fileLine.Substring(0, 12);
    dict[fileStamp] = fileLine;
    // now update the map with results from the text input. This will overwrite text
    // strings that already exist in the file
    foreach (string inputLine in textInputString.Split('\n'))
    {
        string inputStamp = inputLine.Substring(0, 12);
        dict[inputStamp] = inputLine;
    }
    // write out the new file with the updated lines
    foreach (string line in dict.Values)
    {
        outputFile.WriteLine(line);
    }
