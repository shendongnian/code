        public static object DynamicallyCreateGeneric(Type GenericTypeSource, Type SpecificTypeSource)
        {
            System.Type SpecificType = 
                GenericTypeSource.MakeGenericType(
                new System.Type[] { SpecificTypeSource }
                );
            return Activator.CreateInstance(SpecificType);
        }
