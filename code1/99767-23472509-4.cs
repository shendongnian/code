    class BaseFormMiddle1 : BaseForm
    {
        protected BaseFormMiddle1()
        {
        }
        public override void SomeAbstractMethod()
        {
            throw new NotImplementedException();  // this method will never be called in design mode anyway
        }
    }
    class BaseFormMiddle2 : BaseFormMiddle1  // empty class, just to make the VS designer working
    {
    }
