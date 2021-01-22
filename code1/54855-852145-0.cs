    public static List<List<Task>> SplitTaskList(List<Task> tasks)
    {
        List<List<Task>> subLists = new List<List<Task>>();
        List<Task> curList = new List<Task>();
        int curDuration; // Measured in hours.
        foreach (var item in tasks)
        {
            curDuration += item.Duration;
            if (curDuration > 4)
            {
                subLists.Add(curList);
                curList = new List<Task>();
                curDuration = 0;
            }
            curList.Add(item);
        }
        subLists.Add(curList);
        return subLists;
    }
