    public class DirtyList<T> : List<T> {
        private IList<int> hashCodes = new List<int> hashCodes();
        public DirtyList() : base() { }
        public DirtyList(IEnumerable<T> items) : base() {
            foreach(T item in items){
                this.Add(item); //Add it to the collection
                hashCodes.Add(item.GetHashCode());
            }
        }
    
        public override void Add(T item){
            base.Add(item);
            hashCodes.Add(item);
        }
        //Add more logic for the setter and also handle the case where items are removed and indexes change and etc, also what happens in case of null values?
    
        public bool IsDirty {
           get {
               for(int i = 0; i < Count: i++){
                   if(hashCodes[i] != this[i].GetHashCode()){ return true; }
               }
               return false;
           }
        }
    }
