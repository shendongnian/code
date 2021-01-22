    public ActionResult Edit(MyClass class)
    {
        ActionResult rv = null;
        if (class.Editable)
        {
            class.Update();
            rv = View();
        }
        return rv;
    }
