    public static class TypeSwitch
    {
        public static Switch<TSource> On<TSource>(TSource value)
        {
            return new Switch<TSource>(value);
        }
        public sealed class Switch<TSource>
        {
            private readonly TSource value;
            private bool handled = false;
            internal Switch(TSource value)
            {
                this.value = value;
            }
            public Switch<TSource> Case<TTarget>(Action action)
                where TTarget : TSource
            {
                return Case<TTarget>(_ => action());
            }
            public Switch<TSource> Case<TTarget>(Action<TTarget> action)
                where TTarget : TSource
            {
                if (!this.handled && this.value is TTarget)
                {
                    action((TTarget) this.value);
                    this.handled = true;
                }
                return this;
            }
            public void Default(Action action)
            {
                Default(_ => action());
            }
            public void Default(Action<TSource> action)
            {
                if (!this.handled)
                    action(this.value);
            }
        }
    }
