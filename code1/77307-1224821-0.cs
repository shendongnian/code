    public class TypedObjectListView<T> where T : class
    {
        /// <summary>
        /// Create a typed wrapper around the given list.
        /// </summary>
        public TypedObjectListView(ObjectListView olv) {
            this.olv = olv;
        }
        public void BindTo(IList<T> objects) {
           // Manipulate the attached ListView here
        }
        // plus whatever other methods you want
    }
