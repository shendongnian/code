    using System;
    namespace MyDomain.DBDecorations
    {
    
        [AttributeUsage(AttributeTargets.Property)]
        public class StringLength : System.Attribute
        {
            public int Length = 0;
            public StringLength(int taggedStrLength)
            {
                Length = taggedStrLength;
            }
        }
    }
