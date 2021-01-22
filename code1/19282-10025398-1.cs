    public static class TypeSwitch
    {
        public static TypeSwitch<TSource> On<TSource>(TSource value)
        {
            return new TypeSwitch<TSource>(value);
        }
    
        public class TypeSwitch<TSource>
        {
            private TSource value;
            private bool handled = false;
    
            internal TypeSwitch(TSource value)
            {
                this.value = value;
            }
    		
            public TypeSwitch<TSource> Case<TTarget>(Action<TTarget> action)
                where TTarget : TSource
            {
                if (!handled)
                {
                    var sourceType = value.GetType();
                    var targetType = typeof(TTarget);
                    if (targetType.IsAssignableFrom(sourceType))
                    {
                        action((TTarget)value);
                        handled = true;
                    }
                }
    
                return this;
            }
    		
            public void Default(Action<TSource> action)
            {
                if (!handled)
                    action(value);
            }
        }
    }
