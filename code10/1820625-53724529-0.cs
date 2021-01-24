    int fieldsExpected = 49;  // I have counted 49 fields per row of the CSV file. You should check this!
    string fileOut     = "<PATH-AND-FILENAME-FOR-THE-OUTPUT-CSV>";
    string fileIn      = System.Web.HttpContext.Current.Server.MapPath("csv/target_" + DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy") + ".csv");
            
    // Read the file line by line.
    string[] lines = System.IO.File.ReadAllLines(fileIn);
    List<string> newLines = new List<string>();
    // If your csv file has a header row, uncomment this next line
    // newLines.Add(lines[0]);
    // and have the loop start at 'i = 1'
    for (int i = 0; i < lines.Length; i++) {
        string temp = lines[i];
        // Split the line on the separator character. In this case the pipe symbol "|"
        string[] fields = temp.Split('|');
        // Check if the number of fields in this line is correct.
        // It will be less if any of the fields contained a line break.
        // If this is the case, append the next line to this one.
        while (fields.Length < fieldsExpected && i < (lines.Length - 1)) {
            i++;
            temp += lines[i];
            fields = temp.Split('|');
        }
        newLines.Add(temp);
    }
 
    System.IO.File.WriteAllLines(fileOut, newLines.ToArray());
