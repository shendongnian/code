    using System;
    using System.Collections.Immutable;
    namespace ambientcontext {
    public abstract class DateTimeProvider : IDisposable
    {
        private static ImmutableStack<DateTimeProvider> stack = ImmutableStack<DateTimeProvider>.Empty.Push(new DefaultDateTimeProvider());
        protected DateTimeProvider()
        {
            if (this.GetType() != typeof(DefaultDateTimeProvider))
                stack = stack.Push(this);
        }
        
        public static DateTimeProvider Current => stack.Peek();
        public abstract DateTime Today { get; }
        public abstract DateTime Now {get; }
        public void Dispose()
        {
            if (this.GetType() != typeof(DefaultDateTimeProvider))
                stack = stack.Pop();
        }
        // Not visible Default Implementation 
        private class DefaultDateTimeProvider : DateTimeProvider {
            public override DateTime Today => DateTime.Today; 
            public override DateTime Now => DateTime.Now; 
        }
    }
    }
