    public class DataItem
    {
        public BusinessObject Value { get; set; }
        private ModelView modelView;
        public ModelView ModelView
        {
            get
            {
                return modelView;
            }
        }
        public DataItem(ModelView modelView)
        {
            this.modelView = modelView;
        }
    }
