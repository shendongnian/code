    using System.Linq;
    public class WhatClass
    {
        List<SomeOtherClass> _SomeOtherClassItems;
        public List<SomeOtherClass> SomeOtherClassItems { get { return _SomeOtherClassItems.ToList(); } }
    }
