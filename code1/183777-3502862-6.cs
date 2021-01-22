    public static void ReplaceInList<T>(this List<T> my_list,
        T to_replace, T replace_with) where T : IEquatable<T>
    {
        for (int i = 0; i < my_list.Count; i++)
            if (my_list[i].Equals(to_replace))
                my_list[i] = replace_with;
    }
