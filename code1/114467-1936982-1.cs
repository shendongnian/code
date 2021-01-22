       [AttributeUsage(AttributeTargets.Assembly)]
        public class MyCustomAttribute : Attribute {
           string someText;
           public MyCustomAttribute() : this(string.Empty) {}
           public MyCustomAttribute(string txt) { someText = txt; }
         ...
        }
