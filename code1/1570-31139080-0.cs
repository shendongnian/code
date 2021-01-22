    public static class TestDeepClone
        {
            private static readonly List<long> objectIDs = new List<long>();
            private static readonly ObjectIDGenerator objectIdGenerator = new ObjectIDGenerator();
    
            public static bool DefaultCloneExclusionsCheck(Object obj)
            {
                return
                    obj is ValueType ||
                    obj is string ||
                    obj is Delegate ||
                    obj is IEnumerable;
            }
    
            /// <summary>
            /// Executes various assertions to ensure the validity of a deep copy for any object including its compositions
            /// </summary>
            /// <param name="original">The original object</param>
            /// <param name="copy">The cloned object</param>
            /// <param name="checkExclude">A predicate for any exclusions to be done, i.e not to expect IPolicy items to be cloned</param>
            public static void AssertDeepClone(this Object original, Object copy, Predicate<object> checkExclude)
            {
                bool isKnown;
                if (original == null) return;
                if (copy == null) Assert.Fail("Copy is null while original is not", original, copy);
    
                var id = objectIdGenerator.GetId(original, out isKnown); //Avoid checking the same object more than once
                if (!objectIDs.Contains(id))
                {
                    objectIDs.Add(id);
                }
                else
                {
                    return;
                }
    
                if (!checkExclude(original))
                {
                    Assert.That(ReferenceEquals(original, copy) == false);
                }
    
                Type type = original.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
    
                foreach (PropertyInfo memberInfo in propertyInfos)
                {
                    var getmethod = memberInfo.GetGetMethod();
                    if (getmethod == null) continue;
                    var originalValue = getmethod.Invoke(original, new object[] { });
                    var copyValue = getmethod.Invoke(copy, new object[] { });
                    if (originalValue == null) continue;
                    if (!checkExclude(originalValue))
                    {
                        Assert.That(ReferenceEquals(originalValue, copyValue) == false);
                    }
    
                    if (originalValue is IEnumerable && !(originalValue is string))
                    {
                        var originalValueEnumerable = originalValue as IEnumerable;
                        var copyValueEnumerable = copyValue as IEnumerable;
                        if (copyValueEnumerable == null) Assert.Fail("Copy is null while original is not", new[] { original, copy });
                        int count = 0;
                        List<object> items = copyValueEnumerable.Cast<object>().ToList();
                        foreach (object o in originalValueEnumerable)
                        {
                            AssertDeepClone(o, items[count], checkExclude);
                            count++;
                        }
                    }
                    else
                    {
                        //Recurse over reference types to check deep clone success
                        if (!checkExclude(originalValue))
                        {
                            AssertDeepClone(originalValue, copyValue, checkExclude);
                        }
    
                        if (originalValue is ValueType && !(originalValue is Guid))
                        {
                            //check value of non reference type
                            Assert.That(originalValue.Equals(copyValue));
                        }
                    }
    
                }
    
                foreach (FieldInfo fieldInfo in fieldInfos)
                {
                    var originalValue = fieldInfo.GetValue(original);
                    var copyValue = fieldInfo.GetValue(copy);
                    if (originalValue == null) continue;
                    if (!checkExclude(originalValue))
                    {
                        Assert.That(ReferenceEquals(originalValue, copyValue) == false);
                    }
    
                    if (originalValue is IEnumerable && !(originalValue is string))
                    {
                        var originalValueEnumerable = originalValue as IEnumerable;
                        var copyValueEnumerable = copyValue as IEnumerable;
                        if (copyValueEnumerable == null) Assert.Fail("Copy is null while original is not", new[] { original, copy });
                        int count = 0;
                        List<object> items = copyValueEnumerable.Cast<object>().ToList();
                        foreach (object o in originalValueEnumerable)
                        {
                            AssertDeepClone(o, items[count], checkExclude);
                            count++;
                        }
                    }
                    else
                    {
                        //Recurse over reference types to check deep clone success
                        if (!checkExclude(originalValue))
                        {
                            AssertDeepClone(originalValue, copyValue, checkExclude);
                        }
                        if (originalValue is ValueType && !(originalValue is Guid))
                        {
                            //check value of non reference type
                            Assert.That(originalValue.Equals(copyValue));
                        }
                    }
                }
            }
        }
