    [AcceptVerbs(HttpVerbs.Post)]
    [Bind(Prefix="")]
    public ActionResult Save(Person person)
    {
        String s = person.property;
        /* ... */
    }
