    IEnumerable<T> GetChildren<T>(Control owner)
    {
        foreach (Control c in owner.Controls)
        {
            if (c is T)
            {
                yield return c as T;
            }
        }
    }
