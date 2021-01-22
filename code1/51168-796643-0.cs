    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace Whatever.Tickles.Your.Fancy
    {
        public class EnumeratedValueCollection<T> : ReadOnlyCollection<EnumeratedValue<T>>
        {
            public EnumeratedValueCollection()
                : base(ListConstructor()) { }
            public EnumeratedValueCollection(Func<T, bool> selection)
                : base(ListConstructor(selection)) { }
            public EnumeratedValueCollection(Func<T, string> format)
                : base(ListConstructor(format)) { }
            public EnumeratedValueCollection(Func<T, bool> selection, Func<T, string> format)
                : base(ListConstructor(selection, format)) { }
            internal EnumeratedValueCollection(IList<EnumeratedValue<T>> data)
                : base(data) { }
    
            internal static List<EnumeratedValue<T>> ListConstructor()
            {
                return ListConstructor(null, null);
            }
    
            internal static List<EnumeratedValue<T>> ListConstructor(Func<T, string> format)
            {
                return ListConstructor(null, format);
            }
    
            internal static List<EnumeratedValue<T>> ListConstructor(Func<T, bool> selection)
            {
                return ListConstructor(selection, null);
            }
    
            internal static List<EnumeratedValue<T>> ListConstructor(Func<T, bool> selection, Func<T, string> format)
            {
                if (null == selection) selection = (x => true);
                if (null == format) format = (x => GetDescription<T>(x));
                var result = new List<EnumeratedValue<T>>();
                foreach (T value in System.Enum.GetValues(typeof(T)))
                {
                    if (selection(value))
                    {
                        string description = format(value);
                        result.Add(new EnumeratedValue<T>(value, description));
                    }
                }
                return result;
            }
    
            public bool Contains(T value)
            {
                return (Items.FirstOrDefault(item => item.Value.Equals(value)) != null);
            }
    
            public EnumeratedValue<T> this[T value]
            {
                get
                {
                    return Items.First(item => item.Value.Equals(value));
                }
            }
    
            public string Describe(T value)
            {
                return this[value].Description;
            }
        }
    
        [System.Diagnostics.DebuggerDisplay("{Value} ({Description})")]
        public class EnumeratedValue<T>
        {
            private T value;
            private string description;
            internal EnumeratedValue(T value, string description) {
                this.value = value;
                this.description = description;
            }
            public T Value { get { return this.value; } }
            public string Description { get { return this.description; } }
        }
    
    }
