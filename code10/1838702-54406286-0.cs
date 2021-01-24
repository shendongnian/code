    public class InheritanceInfo
    {
        private class InheritanceChain
        {
            /// <summary>
            /// LinkedList which holds inheritance chain from least derived to most derived for a given Type.
            /// </summary>
            private readonly LinkedList<Type> _linkedList = new LinkedList<Type>();
            /// <summary>
            /// Creates an Inheritance chain for a given type which holds information about base types.
            /// </summary>
            /// <param name="t">Type for which inheritance chain will be created.</param>
            public InheritanceChain(Type t)
            {
                Type type = t;
                do
                {
                    if (type == typeof(object))
                    {
                        break;
                    }
                    _linkedList.AddFirst(type);
                    type = type.BaseType;
                } while (true);
            }
            /// <summary>
            /// First element of LinkedList. This will be used for iteration.
            /// </summary>
            public LinkedListNode<Type> First => _linkedList.First;
        }
        /// <summary>
        /// Dictionary which holds Type vs DerivedTypes information. Basically does the all handling.
        /// </summary>
        private readonly ConcurrentDictionary<Type, SingleStepDerivedTypes> _inheritanceDictionary;
        /// <summary>
        /// InheritanceInfo class holds information about each Type's inheritance tree.
        /// Each Type holds information about one step down the inheritance tree.
        /// Example: public class C:B{}
        ///          public class B:A{}
        ///          public class A  {}
        /// Inheritance infor for class A holds info about only B because C is derived from B and
        /// it is not a direct descendant of A.
        /// </summary>
        public InheritanceInfo() {
            _inheritanceDictionary = new ConcurrentDictionary<Type, SingleStepDerivedTypes>();
        }
        /// <summary>
        /// Updates the given Type inheritance tree info.
        /// </summary>
        /// <param name="type"></param>
        public void Update(Type type) {
            var element = new InheritanceChain(type).First;
            while (element.Next != null) {
                _inheritanceDictionary.AddOrUpdate(element.Value, (_)=>AddValueFactory(element.Next.Value), (_,sdt)=>UpdateValueFactory(element.Next.Value,sdt));
                element = element.Next;
            }
        }
        /// <summary>
        /// Gets all the assignable types for the given type t.
        /// </summary>
        /// <param name="t">Type for which assignable types will be searched.</param>
        /// <returns>All the assignable types for Type t.</returns>
        public IEnumerable<Type> GetAssignables(Type t)
        {
            if(_inheritanceDictionary.TryGetValue(t ,out var derivedTypes) == false) {
                return Array.Empty<Type>();
            }
            var recursive = derivedTypes.GetTypes().SelectMany(tp=>GetAssignables(tp));
            return recursive.Concat(derivedTypes.GetTypes());
        }
        /// <summary>
        /// Add value to the dictionary
        /// </summary>
        /// <param name="t">Type to add to ConcurrentDictionary</param>
        /// <returns>SingleStepDerivedTypes which holds information about derived type t</returns>
        private static SingleStepDerivedTypes AddValueFactory(Type t) {
            var s = new SingleStepDerivedTypes();
            s.Add(t);
            return s;
        }
        /// <summary>
        /// Updates the already created SingleStepDerivedTypes object.
        /// </summary>
        /// <param name="t">Type to add</param>
        /// <param name="sdt">SingleStepDerivedTypes</param>
        /// <returns>Updated SingleStepDerivedTypes.</returns>
        private static SingleStepDerivedTypes UpdateValueFactory(Type t, SingleStepDerivedTypes sdt) {
            sdt.Add(t);
            return sdt;
        }
    }
 
    public class SingleStepDerivedTypes
    {
        /// <summary>
        /// HashSet which holds information about derived Types.
        /// </summary>
        private readonly HashSet<Type> _singleStepDerivedTypes;
        /// <summary>
        /// Constructor ;)
        /// </summary>
        public SingleStepDerivedTypes() {
            _singleStepDerivedTypes = new HashSet<Type>();
        }
        /// <summary>
        /// Adds a Type to the Derived Type information.
        /// </summary>
        /// <param name="type">Type to add.</param>
        public void Add(Type type) {
            _singleStepDerivedTypes.Add(type);
        }
        /// <summary>
        /// Gets the contained information about types.
        /// </summary>
        /// <returns>IEnumerable of Types contained in this object.</returns>
        public IEnumerable<Type> GetTypes() {
            return _singleStepDerivedTypes;
        }
    }
