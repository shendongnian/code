    public class Concept:INotifyPropertyChanged
    {
        //Hide constructor
        protected Concept(){}
        
        public static class Create<TConcept> where TConcept:Concept
        {
            //Construct derived Type calling PropertyProxy.ConstructType
            public static readonly Type Type = PropertyProxy.ConstructType<TConcept, Implementation<TConcept>>(new Type[0], true);
            //Create constructing delegate calling Constructor.Compile
            public static Func<TConcept> New = Constructor.Compile<Func<TConcept>>(Type);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            var caller = PropertyChanged;
            if(caller!=null)
            {
                caller(this, eventArgs);
            }
        }
        //define implementation
        public class Implementation<TConcept> : DefaultImplementation<TConcept> where TConcept:Concept
        {
            public override Func<TBaseType, TResult> OverrideGetter<TBaseType, TDeclaringType, TConstructedType, TResult>(PropertyInfo property)
            {
                return PropertyImplementation<TBaseType, TDeclaringType>.GetGetter<TResult>(property.Name);
            }
            /// <summary>
            /// Overriding property setter implementation.
            /// </summary>
            /// <typeparam name="TBaseType">Base type for implementation. TBaseType must be TConcept, and inherits all its constraints. Also TBaseType is TDeclaringType.</typeparam>
            /// <typeparam name="TDeclaringType">Type, declaring property.</typeparam>
            /// <typeparam name="TConstructedType">Constructed type. TConstructedType is TDeclaringType and TBaseType.</typeparam>
            /// <typeparam name="TResult">Type of property.</typeparam>
            /// <param name="property">PropertyInfo of property.</param>
            /// <returns>Delegate, corresponding to property setter implementation.</returns>
            public override Action<TBaseType, TResult> OverrideSetter<TBaseType, TDeclaringType, TConstructedType, TResult>(PropertyInfo property)
            {
                //This code called once for each declared property on derived type's initialization.
                //EventArgs instance is shared between all events for each concrete property.
                var eventArgs = new PropertyChangedEventArgs(property.Name);
                //get delegates for base calls.
                Action<TBaseType, TResult> setter = PropertyImplementation<TBaseType, TDeclaringType>.GetSetter<TResult>(property.Name);
                Func<TBaseType, TResult> getter = PropertyImplementation<TBaseType, TDeclaringType>.GetGetter<TResult>(property.Name);
                var comparer = EqualityComparer<TResult>.Default;
                return (pthis, value) =>
                {//This code executes each time property setter is called.
                    if (comparer.Equals(value, getter(pthis))) return;
                    //base. call
                    setter(pthis, value);
                    //Directly accessing Concept's protected method.
                    pthis.OnPropertyChanged(eventArgs);
                };
            }
        }
    }
