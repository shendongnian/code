    internal class ClassName
    {
        // Fields
        [CompilerGenerated]
        private MyType <Property>k__BackingField;
>
        // Properties
        public MyType MyProperty
        {
            [CompilerGenerated]
            get
            {
                return this.<Property>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Property>k__BackingField = value;
            }
        }
    }
