        // Generic, parameterized (indexed) "property" template
        public class Property<T>
        {
            // The internal property value
            private T PropVal = default(T);
            // The indexed property get/set accessor 
            //  (Property<T>[index] = newvalue; value = Property<T>[index];)
            public T this[object key]
            {
                get { return PropVal; }     // Get the value
                set { PropVal = value; }    // Set the value
            }
        }
