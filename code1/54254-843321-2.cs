    class Impl : IFace
    {
        public void DoStuff()
        {
            ((IFace)this).SomeMethod();
        }
        void IFace.SomeMethod()
        {
        }
    }
