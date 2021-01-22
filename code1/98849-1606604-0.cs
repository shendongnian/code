    public static _T ExpectException<_T> (Action action) where _T: Exception
    {
        try { action(); }
        catch (_T ex) { return ex; }
        Assert.Fail ("Expected " + typeof(_T));
        return null;
    }
