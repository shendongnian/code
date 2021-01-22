C#
 public static DerivedClass ConvertFromBaseToDerived<BaseClass, DerivedClass>(BaseClass baseClass)
            where BaseClass : class, new()
            where DerivedClass : class, BaseClass, new()
        {
            DerivedClass derived = (DerivedClass)Activator.CreateInstance(typeof(DerivedClass));
            derived.GetType().GetFields().ToList().ForEach(field =>
            {
                var base_ = baseClass.GetType().GetField(field.Name).GetValue(baseClass);
                field.SetValue(derived, base_);
            });
            
            return derived;
        }
