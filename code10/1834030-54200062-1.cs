     public static T CastTo<T>(this ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] item)
        {
            var obj = Activator.CreateInstance(typeof(T), true);
            var padlock = new object();
            Parallel.ForEach(typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public), prop =>
            {
                if (!prop.TryGetAttribute<GldnhrnFieldAttribute>(out var fieldAttribute))
                    return;
                var code = fieldAttribute?.Code;
                if (string.IsNullOrEmpty(code)) return;
                lock (padlock)
                    SetPropertyValue(item, obj, prop);
            });
            return (T)obj;
        }
