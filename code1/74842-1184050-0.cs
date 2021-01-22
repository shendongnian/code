    public void EntryPoint(object template)
    {
        TemplateA a = template as TemplateA;
        if (a != null)
        {
            myFunc(a); //calls myFunc(TemplateA template)
            return;
        }
        TemplateB b = template as TemplateB;
        if (b != null)
        {
            myFunc(b); //calls myFunc(TemplateB template)
            return;
        }
        myFunc(template); //calls myFunc(object template)
    }
