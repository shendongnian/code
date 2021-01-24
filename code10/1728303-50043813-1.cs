    public ActionResult SomeMethod()
    {
        try
        {
            return TryGetTheCorrectResult();
        }
        catch
        {
            return MakeSomeHttpStatusCodeResult();
        }
    }
