    public class ConditionalPlaceHolder : PlaceHolder
    {
        protected override void DataBindChildren()
        {
            if( this.Visible )
            {
                base.DataBindChildren();
            }
        }
    }
