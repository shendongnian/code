    abstract class A
    {
        protected virtual void OnShow()
        {
            UniqueOnShowStuff();
            base.OnShow();
        }
        protected virtual void UniqueOnShowStuff()
        {
         //
        }
    }
    
    class B : A
    {
        protected override void OnShow()
        {
            // Things all B's need to Show
            base.OnShow();
        }
        protected override void UniqueOnShowStuff()
        {
            // Things most B's might want to show but don't have to
        }
    }
    
    class C : B
    {
        protected override void OnShow()
        {
            // Things all C's need to show
            base.OnShow();
        }
        protected override void UniqueOnShowStuff()
        {
            // override without a base call so you don't show B's things
        }
    }
