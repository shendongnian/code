	void MyMain(string[] args)
	{
		{
			Console.Write("Demo of shallow and deep copy, using classes and MemberwiseCopy:\n");
			var Bob = new Person(30, "Lamborghini");
			Console.Write("  Create Bob\n");
			Console.Write("    Bob.Age={0}, Bob.Purchase.Description={1}\n", Bob.Age, Bob.Purchase.Description);
			Console.Write("  Clone Bob >> BobsSon\n");
			var BobsSon = Bob.DeepCopy();
			Console.Write("  Adjust BobsSon details\n");
			BobsSon.Age = 2;
			BobsSon.Purchase.Description = "Toy car";
			Console.Write("    BobsSon.Age={0}, BobsSon.Purchase.Description={1}\n", BobsSon.Age, BobsSon.Purchase.Description);
			Console.Write("  Proof of deep copy: If BobsSon is a true clone, then adjusting BobsSon details will not affect Bob:\n");
			Console.Write("    Bob.Age={0}, Bob.Purchase.Description={1}\n", Bob.Age, Bob.Purchase.Description);
			Debug.Assert(Bob.Age == 30);
			Debug.Assert(Bob.Purchase.Description == "Lamborghini");
			var sw = new Stopwatch();
			sw.Start();
			int total = 0;
			for (int i = 0; i < 100000; i++)
			{
				var n = Bob.DeepCopy();
				total += n.Age;
			}
			Console.Write("  Elapsed time: {0},{1}\n", sw.Elapsed, total);
		}
		{				
			Console.Write("Demo of shallow and deep copy, using structs:\n");
			var Bob = new PersonStruct(30, "Lamborghini");
			Console.Write("  Create Bob\n");
			Console.Write("    Bob.Age={0}, Bob.Purchase.Description={1}\n", Bob.Age, Bob.Purchase.Description);
			Console.Write("  Clone Bob >> BobsSon\n");
			var BobsSon = Bob.DeepCopy();
			Console.Write("  Adjust BobsSon details:\n");
			BobsSon.Age = 2;
			BobsSon.Purchase.Description = "Toy car";
			Console.Write("    BobsSon.Age={0}, BobsSon.Purchase.Description={1}\n", BobsSon.Age, BobsSon.Purchase.Description);
			Console.Write("  Proof of deep copy: If BobsSon is a true clone, then adjusting BobsSon details will not affect Bob:\n");
			Console.Write("    Bob.Age={0}, Bob.Purchase.Description={1}\n", Bob.Age, Bob.Purchase.Description);				
			Debug.Assert(Bob.Age == 30);
			Debug.Assert(Bob.Purchase.Description == "Lamborghini");
			var sw = new Stopwatch();
			sw.Start();
			int total = 0;
			for (int i = 0; i < 100000; i++)
			{
				var n = Bob.DeepCopy();
				total += n.Age;
			}
			Console.Write("  Elapsed time: {0},{1}\n", sw.Elapsed, total);
		}
		{
			Console.Write("Demo of deep copy, using class and serialize/deserialize:\n");
			int total = 0;
			var sw = new Stopwatch();
			sw.Start();
			var Bob = new Person(30, "Lamborghini");
			for (int i = 0; i < 100000; i++)
			{
				var BobsSon = MyDeepCopy.DeepCopy<Person>(Bob);
				total += BobsSon.Age;
			}
			Console.Write("  Elapsed time: {0},{1}\n", sw.Elapsed, total);
		}
		Console.ReadKey();
	}
