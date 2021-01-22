    var newFile = new StringBuilder();
    newFile.AppendLine("Name\tAA\tBB\tCC");
    string oldFile = "data";
    var rows = oldFile.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();
    foreach (var row in rows)
       newFile.AppendLine(string.Join("\t", row.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray()));
    return(newFile.ToString());
