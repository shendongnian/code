    void ReplaceX(ref X x)
    {
        x = new X();
    }
    void Test()
    {
        X x = new X();
        ReplaceX(ref x); // Fine, our local variable x is now replaced
        Y y = new Y();
        ReplaceX(ref y); // Error, since it would replace our local 
                         // variable typed as Y with an instance of X
    }
