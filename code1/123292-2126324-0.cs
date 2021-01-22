    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public static bool IsNullOrEmpty(string value)
    {
        if (value != null)
        {
            return (value.Length == 0);
        }
        return true;
    }
