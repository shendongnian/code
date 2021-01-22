        // Outputs "True"
        Debug.WriteLine(string.IsInterned("") != null);
        // Outputs "True"
        Debug.WriteLine(string.IsInterned(string.Empty) != null);
    It is possible that it *always* pulls from the intern pool, but I haven't confirmed that.
