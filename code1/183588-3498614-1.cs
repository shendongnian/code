    static void Main(string[] args)
        {
           System.Reflection.ConstructorInfo ci = typeof(B).GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)[0];
            B B_Object = (B)ci.Invoke(new object[]{"is reflection evil?"});
            Console.WriteLine(B_Object.PropSetByConstructor);
            Console.ReadLine();
        }
