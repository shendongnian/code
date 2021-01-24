        abstract class BaseClass
        {
            public Object A { get; set; }
    
            //protected virtual void SomeMethod()
            //{
            //    if (!(A is null))
            //    {
            //        //Do thing with A
            //        //This works fine
            //    }
    
            //    if (!(B is null))
            //    {
            //        //Do thing with B
            //        //This doesnt work - But I want to it work
            //    }
            //}
    
            public abstract void SomeMethod();
        }
    
        class ChildClass : BaseClass
        {
            public Object B { get; set; }
    
            public override void SomeMethod()
            {
                //    if (!(A is null))
                //    {
                //        //Do thing with A
                //        //This works fine
                //    }
    
                //    if (!(B is null))
                //    {
                //        //Do thing with B
                //        //This doesnt work - But I want to it work
                //    }
            }
        }
