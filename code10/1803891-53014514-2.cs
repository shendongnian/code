    // WHEN STRING IS MISSING IT BREAKS
    try
    {
        var answer = prop.GetValue(_typesSheet).ToString();
        answers.Add(answer);
    }
    catch
    {
        continue;
    }
