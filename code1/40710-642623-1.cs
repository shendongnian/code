    static Enum GetNextValue(Enum e){
        Array all = Enum.GetValues(e.GetType());
        int i = Array.IndexOf(all, e);
        if(i < 0)
            throw new InvalidEnumArgumentException();
        if(i == all.Length - 1)
            throw new ArgumentException("No more values", "e");
        return (Enum)all.GetValue(i + 1);
    }
