    static class Program
    {
        static void Main()
        {
            string strObj = null;
            Console.WriteLine(strObj.nameof(x => x.Length)); //gets the name of an object's property.
            Console.WriteLine(strObj.nameof(x => x.GetType())); //gets the name of an object's method.
            Console.WriteLine(NameOfHelper.nameof(() => string.Empty)); //gets the name of a class' property.
            Console.WriteLine(NameOfHelper.nameof(() => string.Copy(""))); //gets the name of a class' method.
        }
    }
