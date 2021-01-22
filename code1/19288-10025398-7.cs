    public static class TypeSwitch
    {
        public static Switch<TSource> On<TSource>(TSource value)
        {
            return new Switch<TSource>(value);
        }
    
        public class Switch<TSource>
        {
            private TSource value;
            private bool handled = false;
    
            internal Switch(TSource value)
            {
                this.value = value;
            }
    		
            public Switch<TSource> Case<TTarget>(Action<TTarget> action)
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
