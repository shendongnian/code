    usingsLines = new HashSet<string>();
    newFile = new StringBuilder();
    foreeach (file in listOfFiles)
    {
        var textFromFile = file.ReadToEnd();
        var usingOperators = textFromFile.GetUsings();
        var fileBody = textFromFile.GetBody();
        newFile+=fileBody ;
    }
    newFile = usingsLines.ToString() + newFile;
    // As a result if will have something like this
    // using usingsfromFirstFile;
    // using usingsfromSecondFile;
    // 
    // namespace FirstFileNamespace
    // {
    // ...
    // }
    // 
    // namespace SecondFileNamespace
    // {
    // ...
    // }
