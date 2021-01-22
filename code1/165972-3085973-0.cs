    public class DB : D<B>
    {
        public override void DoAction()
        {
            // here _member is a B
            _member.DoAction();
        }
    }
    public class DC : D<C>
    {
        public override void DoAction()
        {
            // here _member is a C
            _member.DoAction();
        }
    }
