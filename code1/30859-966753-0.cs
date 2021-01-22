    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RunWithMyTestClassCommandAttribute : RunWithAttribute
    {
       public RunWithMyTestClassCommandAttribute()
                   : base(typeof(MyTestClassCommand)) {}
    }
