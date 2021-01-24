    public class FieldReader<T> {
        private FieldInfo[] _fields;
        public FieldReader() {
            var theType = typeof(T);
            _fields = theType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }
        public void ShowFieldValuesforObject(T obj) {
            foreach (var field in _fields) {
                var val = field.GetValue(obj);
                Debug.WriteLine($"{field.Name}: {val}");
            }
        }
    }
