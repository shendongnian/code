        List<int> list = new List<int>();
        foreach(System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(textbox1.Text,"[0-9]+"))
        {
            list.Add(Convert.ToInt32(match.Value));
        }
