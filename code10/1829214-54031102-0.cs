    // get the lines in an array
    var lines = File.ReadAllLines(file);
    
    // iterate through every line
    for (var index = 0; index < lines.Length; index++)
    {
       // does the line start with the text you expect?
       if (lines[index].StartsWith(findText))
       {
          // awesome, lets split it apart
          var parts = lines[index].Split(':');
          // part 2 (index 1) has your number
          var num = int.Parse(parts[1].Trim());
          // recreate the line minus 1
          lines[index] = $"{findText} {num-1}";
          // no more processing needed
          break;
       }    
    }
    // write the lines to the file
    File.WriteAllLines(file, lines);
