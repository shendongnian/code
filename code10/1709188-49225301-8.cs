    interface IFoo
    {
        void Bar();
    }
    class CFoo : IFoo
    {
        public virtual void Bar()
        {
        }
        void IFoo.Bar()
        {
        }
    }
    class CFoo2 : CFoo
    {
        public override void Bar()
        {
        }
    }
