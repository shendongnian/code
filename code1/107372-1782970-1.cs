    String workingstring = "ABC XYZ category:\"Mobile Accessories\"";
    Regex categoryMatch("category:\"([^\"]+)\"");
    Regex modelMatch("model:\"([^\"]+)\"");
    String category = categoryMatch.Match(workingstring);
    String model = modelMatch.Match(workingstring);
    workingstring = Regex.Replace(workingstring, categoryMatch, "");
    workingstring = Regex.Replace(workingstring, modelMatch, "");
    String name = workingstring; //I assume that the extra data is the name
