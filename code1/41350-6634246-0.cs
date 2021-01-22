    public class ConditionalPlaceHolder : PlaceHolder
    {
        protected override void DataBindChildren()
        {
            if( If() )
            {
                base.DataBindChildren();
            }
        }
        public Func<bool> If { get; set; }
    }
