    using System;
    
    public interface IMutable
    {
        void Mutate();
    }
    
    public static class MutationExtensions
    {
        public static void CallMutate(this IMutable target)
        {
            target.Mutate();
        }
    }
    
    public struct MutableStruct : IMutable
    {
        public int value;
        
        public void Mutate()
        {
            value++;
        }
    }
    
    class Program
    {
        static void Main()
        {
            MutableStruct x = new MutableStruct();
            Console.WriteLine(x.value); // 0
            x.Mutate();
            Console.WriteLine(x.value); // 1
            x.CallMutate();
            Console.WriteLine(x.value); // 1
        }
    }
