    using (IEnumerator<string> iterator = GetExcelColumns())
    {
        iterator.MoveNext();
        string firstAttempt = iterator.Current;
        if (someCondition)
        {
            iterator.MoveNext();
            string secondAttempt = iterator.Current;
            // etc
        }
    }
