    private Class1 class1 = new Class1();
    class1.OnExecute += SomeMethodName;
    public void SomeMethodName(sender obj, EventArgs e)
    {
        logger.Write(class1.ToString());
    }
