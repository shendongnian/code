     [IsNotNullable]
        [IsPK]
        [IsIdentity]
        [SequenceNameAttribute("Id")]
        [Required]
        public Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
    var t = typeof(YourClass);
    var pi = t.GetProperty("Id");
    var attr = (Required[])pi.GetCustomAttributes(typeof(Required), false);
    if (attr.Length > 0) {
        // Use attr[0], you'll need foreach on attr if MultiUse is true
    }
