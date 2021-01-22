    abstract class MyBase {
        [AttributeUsage(AttributeTargets.Property)]
        protected sealed class SpecialAttribute : Attribute {}
    }
    class ShouldBeValid : MyBase {
        [Special] // works fine
        public int Foo { get; set; }
    }
    class ShouldBeInvalid { // not a subclass of MyBase
        [Special] // type or namespace not found
        [MyBase.Special] // inaccessible due to protection level
        public int Bar{ get; set; }
    }
