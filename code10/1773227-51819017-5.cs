    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Test
    {
        public class Counter
        {
            private int _count;
            private string _name;
    
            public Counter(string name)
            {
               **this._name = name;**
                **this._count = 0;**
            }
            public void Increment()
            {
               **this._count++;**
            }
            public void Reset()
            {
                **this._count = 0;**
            }
    
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            public int Value
            {
                get
                {
                    return _count;
                }
                set
                {
                    _count = value;
                }
            }
        }
    }
