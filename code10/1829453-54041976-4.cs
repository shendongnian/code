    private bool MoveNext()
    {
        try
        {
            switch (this.<>1__state)
            {
                case 0:
                    this.<>1__state = -1;
                    this.<sillier>5__1 = this.source.GetEnumerator();
                    this.<>1__state = -3;
                    while (this.<sillier>5__1.MoveNext())
                    {
                        this.<>2__current = this.<sillier>5__1.Current;
                        this.<>1__state = 1;
                        return true;
                    Label_005A:
                        this.<>1__state = -3;
                    }
                    this.<>m__Finally1();
                    this.<sillier>5__1 = null;
                    return false;
    
                case 1:
                    goto Label_005A;
            }
            return false;
        }
        fault
        {
            this.System.IDisposable.Dispose();
        }
    }
