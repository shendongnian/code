    public class EnumFields {
        public List<object> Objects = new List<object> {
            new Class1(),
            new Class2(),
        };
        public void PerformTask () {
            var enumVals = Enum.GetNames(typeof(SomeEnums));
            foreach (var obj in Objects) {
                var objType = obj.GetType();
                var fieldInfos = objType.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                //right around here I get lost.  You have a list of objects (which has two instances right now), 
                //What are you comparing, that every field named SomeInt has the same value??
                //Anyway, here's some code that should help you
                foreach (var fieldInfo in fieldInfos) {
                    if (enumVals.Contains(fieldInfo.Name)) {
                        var fieldObj = fieldInfo.GetValue(obj);
                        var isSame = false;
                        if (fieldObj.GetType() == typeof(int)) {
                            var comparable = (IComparable)fieldObj;
                            var same = comparable.CompareTo(5);
                            isSame = (same == 0);
                        }
                        Debug.WriteLine($"Field: {fieldInfo.Name} of instance of {obj.GetType().Name} (Value: {fieldObj}) is equal to 5:{isSame}");
                    }
                }
            }
        }
    }
