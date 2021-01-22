    class Choice
    {
        private object _value;
        
        public ChoiceEnum CurrentType { get; private set; }
        public Type1 Type1Value
        {
            get { return (Type1) _value; }
            set { _value = value; CurrentType = ChoiceEnum.Type1; }
        }
        public Type2 Type2Value
        {
            get { return (Type2) _value; }
            set { _value = value; CurrentType = ChoiceEnum.Type2; }
        }
    }
