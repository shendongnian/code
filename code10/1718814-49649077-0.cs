    public enum Flow
    {
        All = 0,
        One = 1
    }
    public static void EnumerateEnum()
    {
        foreach (var flow in Enum.GetValues(typeof(Flow)))
        {
            int FlowId = (int)flow;
            string FlowName = flow.ToString();
        }
    }
