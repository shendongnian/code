    public interface IMyInterface
    {
         string GetClassName();
    }
    public static class IMyInterfaceExtensions
    {
        public static void PrintClassName<T>( this T input ) 
            where T : IMyInterface
        {
             Console.WriteLine(input.GetClassName());
        }
    }
