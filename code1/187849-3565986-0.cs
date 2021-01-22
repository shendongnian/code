    string input = "P,MV,A1ZWR,MAV#(X,,), PV,MOV#(X,12,33),LO";
    IList<string> parts = new List<string>();
    int paranthesisCount = 0;
    int lastSplitIndex = 0;
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == '(')
        {
            paranthesisCount++;
            continue;
        }
        if (input[i] == ')')
        {
            paranthesisCount--;
            continue;
        }
        if (input[i] == ',' && paranthesisCount == 0)
        {
            parts.Add(input.Substring(lastSplitIndex, i - lastSplitIndex));
            lastSplitIndex = i + 1;
        }
    }
    if (input.Length - lastSplitIndex > 0)
    {
        parts.Add(input.Substring(lastSplitIndex, input.Length - lastSplitIndex));
    }
