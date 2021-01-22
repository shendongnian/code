        public static HorizontalAlignment Alignment
        {
            get
            {
                if (_Alignment == null)
                {
                    _Alignment = GetAlignment();
                }
                return _Alignment.Value;
            }
            set
            {
                if (_Alignment != value && SetAlignment(value))
                {
                    _Alignment = value;
                    OnAlignmentChanged(new AlignmentChangedEventArgs(value));
                }
            }
        }
