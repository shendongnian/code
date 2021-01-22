    [Serializable]
        [AttributeUsage(AttributeTargets.Property)]
        public class RequiredAttribute : Attribute
        {
            private CheckType[] _requiredtype;
            public RequiredAttribute(params CheckType[] type)
            {
                _requiredtype = type;
            }
            public CheckType[] Requires
            {
                get { return _requiredtype; }
            }
            public static bool CheckRequirements(object applyto, out string errormessages)
            { ...   }
    
            private static bool RequiredSucceeded(object applyto, StringBuilder resultmessage)
            { ...  }
        }
        [Serializable]
        public enum CheckType
        {
            HasValue,       // Checks that the property value is not null
            CheckMinRequirements,  // Will enforce the validation of properties on defined types
            IsNotNullorEmpty, // For strings
            HasElements,  // Elements exist on arrays
            ElementsRequirements // for collections
        }
