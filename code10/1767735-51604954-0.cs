    protected List<AnObject> aFunction(List<AnObject> sortedList)
    {
        //Display groups of UserIDs and PhotoLabels where UserIDs appear 3 or more times in one group (eg: rows 4 and 5 where UserID = 88 and row 6 where UserID = 04 should be eliminated since the UserID = 88 appears just twice in the group and UserID = 04 appears only once in the group).
        //Display only the top most group of UserIDs and exclude any repeating UserIDs(eg: rows 7, 8 and 9 displays the UserID = 1 group.Don't display any other UserID=1 group such as rows 14,15 and 16.
        int pivot = -1;
        int cnt = 0;
        List<AnObject> masterList = new List<AnObject>();
        List<AnObject> subList = new List<AnObject>();
        //List<int> Excluded = new List<int>();
        foreach (AnObject r in sortedList)
        {
            if (pivot != r.UserID)
            {
                if (cnt > 2)
                {
                    masterList.AddRange(subList);
                    //Excluded.Add(pivot);
                }
                subList.Clear();
                pivot = -1;
                cnt = 0;
                //if (!Excluded.Contains(r.UserID))
                if (!masterList.Any(x => x.UserID == r.UserID))
                {
                    pivot = r.UserID;
                }
            }
            subList.Add(r);
            cnt++;
        }
        return masterList;
    }
