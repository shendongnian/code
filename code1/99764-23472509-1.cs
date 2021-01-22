    class BaseFormMiddle1 : BaseForm
    {
        protected BaseFormMiddle1()
        {
            this.Paint += BaseFormMiddle1_PaintFirstTime;
        }
        void BaseFormMiddle1_PaintFirstTime(object sender, PaintEventArgs e)
        {
            this.Paint -= BaseFormMiddle1_PaintFirstTime;
            // Correct BaseForm's controls locations here
        }
        public override void SomeAbstractMethod()
        {
            throw new NotImplementedException();  // this method will never be called in design mode anyway
        }
    }
    class BaseFormMiddle2 : BaseFormMiddle1  // empty class, just to make the VS designer working
    {
    }
