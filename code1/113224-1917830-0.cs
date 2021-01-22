    class Program
    {
        static void Main(string[] args)
        {
            var bar = new Program().Foo();
            // Get a hook to the underlying compiler generated class
            var barType = bar.GetType().UnderlyingSystemType;
            var barCtor = barType.GetConstructor(new Type[] {typeof (Int32)});
            var res = barCtor.Invoke(new object[] {-2}) as IEnumerable<int>;
            
            // Get our enumerator
            var resEnum = res.GetEnumerator();
            resEnum.MoveNext();
            resEnum.MoveNext();
            Debug.Assert(resEnum.Current == 1);
            
            // Extract and save our state
            var nonPublicMap = new Dictionary<FieldInfo, object>();
            var publicMap = new Dictionary<FieldInfo, object>();
            var nonpublicfields = resEnum.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var publicfields = resEnum.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach(var field in nonpublicfields)
            {
                var value = field.GetValue(resEnum);
                nonPublicMap[field] = value;
            }
            foreach (var field in publicfields)
            {
                var value = field.GetValue(resEnum);
                publicMap[field] = value;                
            }
            // Move about
            resEnum.MoveNext();
            resEnum.MoveNext();
            resEnum.MoveNext();
            resEnum.MoveNext();
            Debug.Assert(resEnum.Current == 5);
            
            // Restore state            
            foreach (var kvp in nonPublicMap)
            {
                kvp.Key.SetValue(resEnum, kvp.Value);
            }
            foreach (var kvp in publicMap)
            {
                kvp.Key.SetValue(resEnum, kvp.Value);                
            }
            // Move about
            resEnum.MoveNext();
            resEnum.MoveNext();
            Debug.Assert(resEnum.Current == 3);
        }
        public IEnumerable<int> Foo()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
            yield break;
        }
    }
