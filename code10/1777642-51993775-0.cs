    public interface ISetting<T>
        where T : BaseSettings
    {
        T Settings { get; set; }
        void DoSomething(T settings);
    }
    public class BaseSettings { }
    public class SpecificSettings : BaseSettings { }
    public class BaseClass : ISetting<BaseSettings>
    {
        public CommonProperty commonProperty { get; set; }
        public virtual BaseSettings Settings { get; set; }
        public void DoSomething(BaseSettings settings)
        {
            Settings = settings;
        }
    }
    public class InheritedClass : ISetting<SpecificSettings>
    {
        public CommonProperty commonProperty { get; set; }
        public SpecificSettings Settings { get; set; }
        public void DoSomething(SpecificSettings settings)
        {
            Settings = settings;
        }
    }
