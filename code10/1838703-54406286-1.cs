     public class Objectholder
     {
        /// <summary>
        /// Holds Type vs object information.
        /// Each object is seperated into its own Type.
        /// </summary>
        private readonly ConcurrentDictionary<Type, List<object>> _dict = new ConcurrentDictionary<Type, List<object>>();
        /// <summary>
        /// I already explained about this class before so here I will pass.
        /// </summary>
        private readonly InheritanceInfo inheritanceInfo = new InheritanceInfo();
        /// <summary>
        /// Adds an object to ObjectHolder.
        /// </summary>
        /// <param name="obj">Object to add</param>
        public void AddObject(object obj) {
            _dict.AddOrUpdate(obj.GetType(), t => AddValueFactory(obj), (t, li) => UpdateValueFactory(obj, li));
        }
        /// <summary>
        /// Gets Objects which are assignable to type of T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetObjectsOf<T>() {
            var tree = inheritanceInfo.GetAssignables(typeof(T)).Concat(new[] { typeof(T) });
            return tree.SelectMany(t => _dict[t]).Cast<T>();
        }
        /// <summary>
        /// Adds a value to dictionary.
        /// </summary>
        /// <param name="obj">Object to add.</param>
        /// <returns></returns>
        private List<object> AddValueFactory(object obj)
        {
            inheritanceInfo.Update(obj.GetType());
            var l = new List<object>();
            l.Add(obj);
            return l;
        }
        /// <summary>
        /// Updates a value in dictionary.
        /// </summary>
        /// <param name="obj">Object to add.</param>
        /// <param name="li">List of objects</param>
        /// <returns></returns>
        private List<object> UpdateValueFactory(object obj, List<object> li)
        {
            inheritanceInfo.Update(obj.GetType());
            li.Add(obj);
            return li;
        }
    }
    // Mock classes
    public class A { }
    public class B : A { }
    public class C : B { }
