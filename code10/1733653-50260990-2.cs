        internal class WhatToMineCalculatorResponse
        {
            readonly string _name;
    
            public WhatToMineCalculatorResponse(string name)
            {
                this._name = name;
            }
    
            // I want the key set in this field
            public string Name { get { return _name; } }
    
            // Remainder of class unchanged
        }
