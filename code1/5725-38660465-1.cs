    public class MyClass
    {
        public virtual MyClass DeepClone()
        {
            var returnObj = (MyClass)MemberwiseClone();
            var type = returnObj.GetType();
            var fieldInfoArray = type.GetRuntimeFields().ToArray();
            foreach (var fieldInfo in fieldInfoArray)
            {
                object sourceFieldValue = fieldInfo.GetValue(this);
                if (!(sourceFieldValue is MyClass))
                {
                    continue;
                }
                var sourceObj = (MyClass)sourceFieldValue;
                var clonedObj = sourceObj.DeepClone();
                fieldInfo.SetValue(returnObj, clonedObj);
            }
            return returnObj;
        }
    }
