    if(reader.HasRows)
    {
         while (reader.Read())
         {
             string a = reader.GetString(1);
             string b = reader.GetString(3);
             string c = reader.GetString(4);
             string d = reader.GetString(5);
             await context.PostAsync(...........);
         }
    }
    else
    {
        await context.PostAsync("Record not found");
    }
