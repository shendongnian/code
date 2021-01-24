        public abstract class AbstractClass
        {
            public void OnlyInAbstract() {
                Console.WriteLine("You are stuck with OnlyInAbstract in abstract class unless you use new keyword.");
            }
            public virtual void OnlyInAbstractForNow()
            {
                Console.WriteLine("You have reached abstract class for now. However, override me for changed behaviour.");
            }
            public abstract void MustImplement();
        }
        public class FirstChild : AbstractClass
        {
            public override void MustImplement()
            {
                Console.WriteLine("You called MustImplement in FirstChild. Nothing else to see here.");
            }
            public override void OnlyInAbstractForNow()
            {
                base.OnlyInAbstractForNow();
                Console.WriteLine("I see you changed my behaviour in FirstChild to extend it after abstract class was done with.");
            }
            public new void OnlyInAbstract()
            {
                Console.WriteLine("Looks like we are making an all new OnlyInAbstract method in child class.");
            }
        }
        static void Main(string[] args)
        {
            AbstractClass abstractClass = new FirstChild();
            abstractClass.MustImplement();
            abstractClass.OnlyInAbstract();
            (abstractClass as FirstChild).OnlyInAbstract();
            abstractClass.OnlyInAbstractForNow();
            Console.Read();
        }
