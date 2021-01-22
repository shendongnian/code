    //Rough Psuedo Code
    public class TrackedList<T> : List<T>
    {
        public bool StartTracking {get; set; }
        private List<T> InitialList { get; set; }
    
        CTOR
        {
            //Instantiate Both Lists...
        }
    
        ADD(item)
        {
            if(!StartTracking)
            {
                Base.Add(item);
                InitialList.Add(item);
            }
            else
            {
                Base.Add(item);
            }
        }
    
        public bool IsDirty
        {
           get
           {
               Check if theres any differences between initial list and self.
           }
        }
    }
