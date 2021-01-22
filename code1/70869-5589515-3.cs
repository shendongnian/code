    enum MyEnum { A, B, C };
    
    MyEnum m_e = MyEnum.B;
    
    unsafe /*_ctor*/ CompareExchangeEnum()
    {
        MyEnum e = m_e;
        fixed (MyEnum* ps = &m_e)
            if (Interlocked.CompareExchange(ref *(int*)ps, (int)(e | MyEnum.C), (int)e) == (int)e)
            {
                /// change accepted, m_e == B | C
            }
            else
            {
                /// change rejected
            }
    }
