        bool isMatch = false;
        int matchIndex = -1;
        DateTime resultDate = = new DateTime();
        foreach(ListViewItem lvItem in listView1.Items)
        {
            if(DateTime.TryParse(lvItem.Text, out resultDate ))
            {
               isMatch = true;
               matchIndex = lvItem.Index;
               break;
            }
        }
        if(isMatch) Console.WriteLine("match at index : " + matchIndex.ToString() + " = " + resultDate.ToString());
