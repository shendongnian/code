    var sbld = new System.Text.StringBuilder(); 
    var rows = System.IO.File.ReadAllLines(@"C:\YourUserTextFile.txt");
    foreach(var row in rows)
    {
        var id = row.Split(',')[0];
        var name = row.Split(',')[1];
        var country = row.Split(',')[2];
        // do update here
        sbld.AppendLine(String.Format("{0},{1},{2}", id, name, country));
    }
    System.IO.File.WriteAllText(sbld.ToString());
   
