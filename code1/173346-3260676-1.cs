    public class WhatClass {
        public WhatClass() {
            _SomeOtherClassItems = new List<SomeOtherClass>();
            SomeOtherClassItems = _SomeOtherClassItems.AsReadOnly();
        }
        List<SomeOtherClass> _SomeOtherClassItems;
    
        public ReadOnlyCollection<SomeOtherClass> SomeOtherClassItems { get; private set; }
    }
