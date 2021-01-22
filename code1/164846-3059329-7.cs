    public class Base
    {
        private string className;
        public string ClassName
        {
            get
            {
                if(string.IsNullOrEmpty(className))
                    className = this.GetType().Name;
                return className;
            }
        }
    }
