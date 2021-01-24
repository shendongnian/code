    String scoresFilePath = @"C:\scores.csv";
    
    //
    // Create DataTable
    //
    DataColumn nameColumn = new DataColumn("name", typeof(String));
    DataColumn scoreColumn = new DataColumn("score", typeof(int));
    
    DataTable scores = new DataTable();
    scores.Columns.Add(nameColumn);
    scores.Columns.Add(scoreColumn);
    
    //
    // Read CSV and populate DataTable
    //
    using (StreamReader streamReader = new StreamReader(scoresFilePath))
    {
        while (!streamReader.EndOfStream)
        {
            String[] row = streamReader.ReadLine().Split(',');
    
            if (row[1] != "score")
            {
                scores.Rows.Add(row);
            }
        }
    }
    
    Boolean scoreFound = false;
    
    //
    // If user exists and new score is higher, update 
    //
    foreach(DataRow score in scores.Rows)
    {
        if((String) score["name"] == player.Name)
        {
            if ((int) score["score"] < player.Score)
            {
                score["score"] = player.Score;
            }
    
            scoreFound = true;
            break;
        }
    }
    
    //
    // If user doesn't exist then add user/score
    //
    if(!scoreFound)
    {
        scores.Rows.Add(player.Name, player.Score);
    }
    
    //
    // Write changes to CSV (empty then rewrite)
    //
    File.WriteAllText(scoresFilePath, string.Empty);
    
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("name,score");
    
    foreach (DataRow score in scores.Rows)
    {
        stringBuilder.AppendLine(score["name"] + "," + score["score"]);
    }
    
    File.WriteAllText(scoresFilePath, stringBuilder.ToString());
