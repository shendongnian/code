    private SelfUpdatingExpression<int> m_fooExp = new SelfUpdatingExpression<int>(this, ()=> Foo * Foo);
    
    public int Foo
    {
        get
        { 
            return  m_fooExp.Value;   
        }
    }
 
