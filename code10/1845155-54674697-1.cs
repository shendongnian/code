    using System.Linq;
    using System.Data;
    using System.IO;
    using System.Text;
 
         //get source file
        string fullFileName = @"C:\Input Folder\SourceFile.txt";
        
        DataTable dt = new DataTable();
        StringBuilder sb = new StringBuilder();
        //output .sql script
        string sqlScript = @"C:\Output Folder\UpdateScript.SQL";
    
       using (StreamReader sr = new StreamReader(fullFileName))
        {
        string firstLine = sr.ReadLine();
        string[] headers = firstLine.Split(';');
    
        //define columns for data table
        foreach (string h in headers)
        {
            dt.Columns.Add(h);
        }
    
        int columnCount = dt.Columns.Count;
        
        string line = sr.ReadLine();
        
        while (line != null)
        {
        string[] fields = line.Split(';');
    
        int currentLength = fields.Count();
    
        if (currentLength < columnCount)
        {
            while (currentLength < columnCount)
            {
                line += sr.ReadLine();
                currentLength = line.Split(';').Count();
            }
            fields = line.Split(';');
        }
        //load data table
        dt.Rows.Add(fields);
        line = sr.ReadLine();
       }
                        
        foreach (DataRow dr in dt.Rows)
           {
            sb.AppendLine("UPDATE Contact SET " + dt.Columns[1] + " = '" + dr[1] + 
          "' WHERE ISNULL(" + dt.Columns[0] + ", '') = '" + dr[0] + "'");
    
            //extra lines and GO batch separator added between UPDATE statements for formating
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("GO");
            sb.AppendLine(Environment.NewLine);
           }   
                //output UPDATE commands as .sql script file
                File.WriteAllText(sqlScript, sb.ToString());
          }
