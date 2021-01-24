    private void GametableHistory(bool success, Int32 gametable_no, Int32 year, Int32 month, Int32 day, Int32 shoe_no, bc_gametable_history_list list)
    {
        if (gametable_no != 1) // Because you're only interested in table 1
            return;
        tzPlayInfo.Instance.gametable_history_list = list;
    
        string s1 = "";
    
        for (int i = 0; i < list.Count; i++)
        {
            s1 += list[i].r;
            s1 += ",";
        }
    
        Debug.Log("This is a new history " + gametable_no + " = " + s1);
    }
