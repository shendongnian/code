    if (gametable_no == 1)
        {
            for (int i = 0; i < tzPlayInfo.Instance.bc_gametable_history_list.Count; i++)
            {
                newString[0] += tzPlayInfo.Instance.bc_gametable_history_list[i].r;
                newString[0] += ",";
            }
            string[] newChars = newString[0].Split(',');
