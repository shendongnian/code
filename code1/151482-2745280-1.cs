    private bool Check(List<MyItem> list)
    {
        list.Sort();
        for (int pos = 1; pos < list.Count; pos++)
        {
            if (!CheckCollisionWithPrevious(list, pos))
            {
                MarkAsFailed();
                return false;
            }
            MarkAsGood();
        }
        return true;
    }
    private bool CheckCollisionWithPrevious(List<MyItem> list, int pos)
    {
        bool checkOk = false;
        var previousItem = list[pos - 1];
        // Doing some checks ...
        return checkOk;
    }
