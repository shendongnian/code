            public abstract class Base<TSelf, TParameter>
            where TSelf : Base<TSelf, TParameter>, new()
        {
            protected const string FactoryMessage = "Use YourClass.Create(...) instead";
            public static TSelf Create(TParameter parameter)
            {
                var me = new TSelf();
                me.Initialize(parameter);
                return me;
            }
            [Obsolete(FactoryMessage, true)]
            protected Base()
            {
            }
            protected virtual void Initialize(TParameter parameter)
            {
            }
        }
        public abstract class BaseWithConfig<TSelf, TConfig>: Base<TSelf, TConfig>
            where TSelf : BaseWithConfig<TSelf, TConfig>, new()
        {
            public TConfig Config { get; private set; }
            [Obsolete(FactoryMessage, true)]
            protected BaseWithConfig()
            {
            }
            protected override void Initialize(TConfig parameter)
            {
                this.Config = parameter;
            }
        }
        public class MyService : BaseWithConfig<MyService, (string UserName, string Password)>
        {
            [Obsolete(FactoryMessage, true)]
            public MyService()
            {
            }
        }
        public class Person : Base<Person, (string FirstName, string LastName)>
        {
            [Obsolete(FactoryMessage,true)]
            public Person()
            {
            }
            protected override void Initialize((string FirstName, string LastName) parameter)
            {
                this.FirstName = parameter.FirstName;
                this.LastName = parameter.LastName;
            }
            public string LastName { get; private set; }
            public string FirstName { get; private set; }
        }
       
        [Test]
        public void FactoryTest()
        {
            var notInitilaizedPerson = new Person(); // doesn't compile because of the obsolete attribute.
            Person max = Person.Create(("Max", "Mustermann"));
            Assert.AreEqual("Max",max.FirstName);
            var service = MyService.Create(("MyUser", "MyPassword"));
            Assert.AreEqual("MyUser", service.Config.UserName);
        }
