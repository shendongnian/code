    public ActionResult SomeMethod()
    {
        ActionResult result;
        try
        {
            result = TryGetTheCorrectResult();
        }
        catch
        {
            result = MakeSomeHttpStatusCodeResult();
        }
        return result;
    }
