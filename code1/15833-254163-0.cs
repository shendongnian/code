    string list = "Fred,Sam,Mike,Sarah";
    StringBuilder sb = new StringBuilder();
    
    string[] listArray = list.Split(new char[] { ',' });
    
    for (int i = 0; i < listArray.Length; i++)
    {
        sb.Append("'").Append(listArray[i]).Append("'");
        if (i != (listArray.Length - 1))
            sb.Append(",");
    }
    string newList = sb.ToString();
    Console.WriteLine(newList);
