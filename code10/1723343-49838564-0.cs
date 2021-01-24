    // rnd is kinda the de-facto standard name for instances of the Random class
    var rnd = new Random();             
    // Same for sb and StringBuilder
    var sb = new StringBulider();
    // And the same for i and for loops...
    for (int i = userAmountNumber; i <= userAmountNumber; i++) 
    { 
        // Appends the string representation of the next random number to the string builder
        sb.AppendLine(rnd.Next(1, 100).ToString());
    }
    // Appends all the content of the string builder to the text file.
    // If the file does not exists, creates it.
    System.IO.File.AppendAllText(filepath, sb.ToString());
