    class AdapterHelper<T1, T2>
    {
        public T1 Adapt(T2 source)
        {
            T1 targetItem = Activator.CreateInstance<T1>();
            var props = typeof(T1).GetProperties();
            var targetProps = typeof(T2).GetProperties();
            foreach (var prop in props)
            {
                foreach (var targetProp in targetProps)
                {
                    if (prop.Name == targetProp.Name)
                    {
                        targetProp.SetValue(targetItem, prop.GetValue(source));
                        //assign
                    }
                }
            }
            return targetItem;
        }
    }
