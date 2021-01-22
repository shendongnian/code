    public class MyWrapper
    {
        public MyWrapper(SourceObject sourceObject)
        {             
        }
        private List<decimal> points;
        [DataMember]   
        public List<decimal> Points
        {
            get
            {
                if (this.points == null)
                {
                    this.points = sourceObject.ListPoints();
                }
                return this.points;
            }
        }
    }
