    class CustomResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            if (type.IsClass)
            {
                ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
                if (ctor != null)
                {
                    object referenceInstance = ctor.Invoke(null);
                    foreach (JsonProperty prop in props.Where(p => p.Readable))
                    {
                        prop.ShouldSerialize = instance =>
                        {
                            object val = prop.ValueProvider.GetValue(instance);
                            object refVal = prop.ValueProvider.GetValue(referenceInstance);
                            return !ObjectEquals(val, refVal);
                        };
                    }
                }
            }
            return props;
        }
        private bool ObjectEquals(object a, object b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a == null || b == null) return false;
            if (a is IEnumerable && b is IEnumerable && !(a is string) && !(b is string))
                return EnumerableEquals((IEnumerable)a, (IEnumerable)b);
            return a.Equals(b);
        }
        private bool EnumerableEquals(IEnumerable a, IEnumerable b)
        {
            IEnumerator enumeratorA = a.GetEnumerator();
            IEnumerator enumeratorB = b.GetEnumerator();
            bool hasNextA = enumeratorA.MoveNext();
            bool hasNextB = enumeratorB.MoveNext();
            while (hasNextA && hasNextB)
            {
                if (!ObjectEquals(enumeratorA.Current, enumeratorB.Current)) return false;
                hasNextA = enumeratorA.MoveNext();
                hasNextB = enumeratorB.MoveNext();
            }
            return !hasNextA && !hasNextB;
        }
    }
