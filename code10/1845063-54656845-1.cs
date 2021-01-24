    public class A
    {
        [Display(Name = "Some Property")]
        public virtual int SomeProperty { get; set; }
    }
    public class B : A
    {
        [MyRequired]
        public override int SomeProperty { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class MyRequiredAttribute : RequiredAttribute
    {
    }
