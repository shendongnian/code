    using System;
    class BaseClass
    {
        public string name;
        public BaseClass()
        {
            this.name = "MyName";
        }
        public virtual void A()
        {
            Console.WriteLine("Looks like I have no surname");
        }
    }
    class DerivedClass : BaseClass
    {
        public string surname;
        public DerivedClass()
        {
            this.surname = "MySurname";
        }
        public override void A()
        {
            Console.WriteLine(this.surname);
        }
    }
    class AnotherDerivedClass : BaseClass
    {
        public string IHaveNoSurname;
        public AnotherDerivedClass()
        {
            this.IHaveNoSurname = "Well, no surname for me...";
        }
    }
    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<BaseClass> MyClasses = new List<BaseClass>();
                MyClasses.Add(new DerivedClass());
                MyClasses.Add(new AnotherDerivedClass());
                foreach (BaseClass MyClasse in MyClasses)
                {
                    Console.WriteLine(MyClasse.GetType());
                    MyClasse.A();
                }
                Console.ReadKey();
            }
        }
    }
