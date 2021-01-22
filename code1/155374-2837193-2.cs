    var sbld = new System.Text.StringBuilder(); 
    var rows = System.IO.File.ReadAllLines(@"C:\YourUserTextFile.txt");
    foreach(var row in rows)
    {
        if(!updateThisRow(row)) 
        {
            var ar = row.Split(',');
            var id = ar[0];
            var name = ar[1];
            var country = ar[2];
            // do update here
            sbld.AppendLine(String.Format("{0},{1},{2}", id, name, country));
        }
        else
        {
            sbld.AppendLine(row);
        }
    }
    System.IO.File.WriteAllText(C:\YourUserTextFile.txt", sbld.ToString());
