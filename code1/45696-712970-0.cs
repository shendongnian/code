	interface Animal
	{
		void Run();
	}
	interface Machine
	{
		void Run();
	}
	class Aibo : Animal, Machine
	{
		void Animal.Run()
		{
			System.Console.WriteLine("Aibo goes for a run.");
		}
		void Machine.Run()
		{
			System.Console.WriteLine("Aibo starting up.");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Aibo a = new Aibo();
			((Machine)a).Run();
			((Animal)a).Run();
		}
	}
