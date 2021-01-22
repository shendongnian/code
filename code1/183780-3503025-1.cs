    public static void ReplaceStringInListWithAnother( this List<string> my_list, string to_replace, string replace_with)
    {
        for (int i = 0; i < my_list.Count; ++i)
        {
            if (my_list[i] == to_replace)
            {
                my_list[i] = replace_with;
            }
        }
    }
