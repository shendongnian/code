    List<string> result = new List<string>();
    for (int i = 0; i < List1.Count; i++)
    {
        string resStr = List1.get(i);
        if (List2.Count > i && List2.get(i).Split("|")[0].equals(resStr.Split("|")[0]))
            resStr = List2.get(i);
        result.Add(List2.get(i));
    }
    //set the result to List1
    List1 = result;
