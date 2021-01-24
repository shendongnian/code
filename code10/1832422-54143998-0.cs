    // Create a string array with the lines of text
    string[] lines = File.ReadAllLines(path-of-file);
    
    // Write the string array to a new file named "ouput.xml".
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath,"output.xml"))) {
        foreach (string line in lines)
            outputFile.WriteLine("<!--" + line + "-->");
    }
