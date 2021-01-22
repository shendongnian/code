    public class WhatTheHeck
    {
        public string PrivateSet { get; private set; } // matches ctor param name
        public string GetOnly { get; } // matches ctor param name
        private readonly string _indirectField;
        public string Indirect => $"Inception of: {_indirectField} "; // matches ctor param name
        public string RealIndirectFieldVaule => _indirectField;
        public WhatTheHeck(string privateSet, string getOnly, string indirect)
        {
            PrivateSet = privateSet;
            GetOnly = getOnly;
            _indirectField = indirect;
        }
    }
