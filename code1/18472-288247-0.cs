    public class A
    {
        delegate void BDelegate();
        public void BegineBMethod()
        {
            BDelegate b_method = new BDelegate(B.b);
            b_method.BeginInvoke(BCallback, null);
        }
        void BCallback(IAsyncResult ar)
        {
           // cleanup/get return value/check exceptions here
        }
    }
    
