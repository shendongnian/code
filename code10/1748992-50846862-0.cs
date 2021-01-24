    public class Program
    {
        public static void Main()
        {
            A a = new A();
            B b = new B();
            a.Attack(b);
            b.Attack(a);
            Console.WriteLine(typeof(A));
            Console.WriteLine(typeof(B));
            Console.WriteLine(typeof(A) == a.GetType());
            Console.WriteLine(typeof(B) == a.GetType());
            Console.ReadLine();
        }
        public abstract class Character
        {
            public abstract void Attack(Character c);
        }
        public class A : Character
        {
            public override void Attack(Character t)
            {
                if (t.GetType() == typeof(A))
                {
                    Console.WriteLine("A attacked type A");
                    return;
                }
                if (t.GetType() == typeof(B))
                {
                    Console.WriteLine("A attacked type B");
                    return;
                }
                if (t.GetType() == typeof(C))
                {
                    Console.WriteLine("A attacked type C");
                    return;
                }
            }
        }
        public class B : Character
        {
            public override void Attack(Character t)
            {
                if (t.GetType() == typeof(A))
                {
                    Console.WriteLine("B attacked type A");
                    return;
                }
                if (t.GetType() == typeof(B))
                {
                    Console.WriteLine("B attacked type B");
                    return;
                }
                if (t.GetType() == typeof(C))
                {
                    Console.WriteLine("B attacked type C");
                    return;
                }
            }
        }
        public class C : Character
        {
            public override void Attack(Character t)
            {
                if (t.GetType() == typeof(A))
                {
                    Console.WriteLine("C attacked type A");
                    return;
                }
                if (t.GetType() == typeof(B))
                {
                    Console.WriteLine("C attacked type B");
                    return;
                }
                if (t.GetType() == typeof(C))
                {
                    Console.WriteLine("C attacked type C");
                    return;
                }
            }
        }
    }
