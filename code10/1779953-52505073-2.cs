    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ExposeToViewAttribute : Attribute
    {
        public string Name { get; set; }
        public ExposeToViewAttribute([System.Runtime.CompilerServices.CallerMemberName]string name = "")
        {
            this.Name = name;
        }
    }
