      private IEnumerable<PropertyInfo> SelectProperties( Type type )
        {
            const BindingFlags bindingFlags = BindingFlags.Instance | 
                BindingFlags.DeclaredOnly
                                              | BindingFlags.Public;
            return from property
                       in type.GetProperties( bindingFlags )
                   where property.CanWrite &&
                         !property.IsDefined(typeof(SuppressNotify))
                   select property;
        }
        [OnLocationSetValueAdvice, MethodPointcut( "SelectProperties" )]
        public void OnSetValue( LocationInterceptionArgs args )
        {
            if ( args.Value != args.GetCurrentValue() )
            {
                args.ProceedSetValue();
               this.OnPropertyChangedMethod.Invoke(null);
            }
        }
