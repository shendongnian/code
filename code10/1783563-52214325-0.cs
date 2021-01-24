    class Human {
        public Human() {
            Console.WriteLine("I am human");
        }
        public Human(int i) {
            Console.WriteLine("I am human " + i);
        }
    }
    class Man : Human {
        public Man() {
            Console.WriteLine("I am man");
        }
        public Man(int i) {
            Console.WriteLine("I am man " + i);
        }
    }
	static void Main(string[] args)
	{
		Man m1 = new Man();
		Man m2 = new Man(2);
		Console.ReadLine();
	}
