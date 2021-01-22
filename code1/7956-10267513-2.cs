        public interface IDeepClonable<T> where T : class
        {
            T DeepClone();
        }
        public class MyObj : IDeepClonable<MyObj>
        {
            public MyObj Clone()
            {
                var myObj = new MyObj();
                myObj._field1 = _field1;//value type
                myObj._field2 = _field2;//value type
                myObj._field3 = _field3;//value type
                if (_child != null)
                {
                    myObj._child = _child.DeepClone(); //reference type .DeepClone() that does the same
                }
                int len = _array.Length;
                myObj._array = new MyObj[len]; // array / collection
                for (int i = 0; i < len; i++)
                {
                    myObj._array[i] = _array[i];
                }
                return myObj;
            }
            private bool _field1;
            public bool Field1
            {
                get { return _field1; }
                set { _field1 = value; }
            }
            private int _field2;
            public int Property2
            {
                get { return _field2; }
                set { _field2 = value; }
            }
            private string _field3;
            public string Property3
            {
                get { return _field3; }
                set { _field3 = value; }
            }
            private MyObj _child;
            private MyObj Child
            {
                get { return _child; }
                set { _child = value; }
            }
            private MyObj[] _array = new MyObj[4];
        }
