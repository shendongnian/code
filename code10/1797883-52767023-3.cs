    string[] data = File.ReadAllText("filepath.txt").Split('|');
    Account account = new Account();
    foreach (string item in data)
    {
        string[] sitem = item.Split(':');
        switch(sitem[0].Trim())
        {
            case "AccountID":
               account.Id = int.Parse(sitem[1]); break;
            case "Name":
               account.Name = int.Parse(sitem[1]); break;  
               ....
        }
    }
