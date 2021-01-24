    public class ContainerClass : Control
    {
        private NestedClass _nestedClassInstance = new NestedClassInstance();
        public NestedClass NestedClassInstance
        {
            get => _nestedClassInstance;
            set
            {
                if (_nestedClassInstance != null)
                    _nestedClassInstance.PropertyChanged -= delegate { this.Invalidate(); };
                _nestedClassInstance = value;
                _nestedClassINstance.PropertyChanged += delegate { this.Invalidate(); };
            }
        }
    }
