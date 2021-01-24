    abstract class Character {
        public void Attack(Character c) {
            ((dynamic)this).DoAttack((dynamic)c);
        }
    }
    class A : Character {
        public void DoAttack(A a) { Console.WriteLine("A attacks A"); }
        public void DoAttack(B b) { Console.WriteLine("A attacks B"); }
        public void DoAttack(C c) { Console.WriteLine("A attacks C"); }
    }
    class B : Character {
        public void DoAttack(A a) { Console.WriteLine("B attacks A"); }
        public void DoAttack(B b) { Console.WriteLine("B attacks B"); }
        public void DoAttack(C c) { Console.WriteLine("B attacks C"); }
    }
    class C : Character {
        public void DoAttack(A a) { Console.WriteLine("C attacks A"); }
        public void DoAttack(B b) { Console.WriteLine("C attacks B"); }
        public void DoAttack(C c) { Console.WriteLine("C attacks C"); }
    }
