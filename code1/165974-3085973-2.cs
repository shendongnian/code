    public class DB : D<B>
    {
        public override void DoSomethingOnlyBAndCCanDo()
        {
            _member.DoSomethingOnlyBCanDo();
        }
    }
    public class DC : D<C>
    {
        public override void DoSomethingOnlyBAndCCanDo()
        {
            _member.DoSomethingOnlyCCanDo();
        }
    }
