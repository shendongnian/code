        static void Main(string[] args) {
            foreach (var student in Students) 
                student.CloneFrom(Student);
        }
        public static void CloneFrom<T>(this T ToObj, T FromObj) {
            CloneFrom(ToObj, FromObj, new Dictionary<object, object>());
        }
        private static FieldInfo[] GetMemberFields(this Type type) {
            return type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }
        private static void CloneFrom<T>(T ToObj, T FromObj, Dictionary<object, object> Values) {
            Values.Add(FromObj, ToObj); //The dictionary is used to prevent infinite recursion
            var fields = ToObj.GetType().GetMemberFields();
            object value = null;
            object othervalue = null;
            foreach (var field in fields) {
                value = field.GetValue(FromObj);
                othervalue = field.GetValue(ToObj);
                if (object.Equals(othervalue, value)) continue;
                if (value != null && Values.ContainsKey(value)) {
                    //Prevent recursive calls: objA.fieldB.fieldC = objA
                    field.SetValue(ToObj, Values[value]);
                } else if (othervalue != null && value != null && !field.FieldType.IsPrimitive && !field.FieldType.IsValueType && !(value is string)
                    && field.FieldType.GetMemberFields().Any()) {
                    //Do not overwrite object references
                    CloneFrom(othervalue, value, Values);
                } else {
                    field.SetValue(ToObj, value);
                }
            }
        }
