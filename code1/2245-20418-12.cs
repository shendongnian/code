    public class DisplayWrapper
    {
        private UnderlyingClass underlyingObject;
        public DisplayWrapper(UnderlyingClass u)
        {
            underlyingObject = u;
        }
        [DisplayOrder(1)]
        public int SomeInt
        {
            get
            {
                return underlyingObject .SomeInt;
            }
        }
        [DisplayOrder(2)]
        public DateTime SomeDate
        {
            get
            {
                return underlyingObject .SomeDate;
            }
        }
    }
