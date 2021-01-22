    public static void MySwitchWithEnumerable(int switchcase, int startNumber, int endNumber, Action action)
    {
        if(Enumerable.Range(startNumber, endNumber).Contains(switchcase))
            action();
    }
