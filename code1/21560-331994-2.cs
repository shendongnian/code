    public class FooDataTable 
    {
        //  -- Other implementation
        public FooRow MyNewFooRow()
        {
            FooRow fr = this.NewFooRow(); // call the original factory
            fr.RegisterEvents();
            return fr;
        }
     }
