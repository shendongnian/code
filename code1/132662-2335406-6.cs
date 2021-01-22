        public interface IFormField
        {
            object GetValue();
            string Name { get; }
        }
    
        public interface IFormField<T> : IFormField
        {
            T GetValue();
            
        }
