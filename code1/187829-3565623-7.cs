    public void CallAllMyMethodsInContents()
        {
            foreach (T myClass in Contents)
            {
                myClass.MyMethod();
            }
        }
