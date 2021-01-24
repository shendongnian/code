    public class D : A {
        new public int MyProtected {
    		get {return base.MyProtected;}
    		set { base.MyProtected = value; }
    	}
        new public int MyProtectedInternal {
    		get { return base.MyProtectedInternal; }
    		set { base.MyProtectedInternal = value; }
    	}
    }
    public class C : Collection<D>
    {
        C MyC { get; set; }
        C()
        {
            MyC[0].MyProtected++;
            MyC[0].MyInternal++;
            MyC[0].MyPublic++;
            MyC[0].MyProtectedInternal++;
        }
    }
