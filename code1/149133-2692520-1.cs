    static B ToB(this A a)
    {
        switch (a)
        {
            case A.One:
                return B.One;
            case A.Two:
                return B.Two;
            default:
                throw new NotSupportedException();
        }
    }
