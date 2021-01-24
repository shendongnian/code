    using System;
    
    namespace Sample
    {
        public class Runner
        {
            public static void Main()
            {
                TextProcessorsCache.GetInstance<TextProcessor1>();
                TextProcessorsCache.GetInstance<TextProcessor2>();
                TextProcessorsCache.GetInstance<TextProcessor1>();
                TextProcessorsCache.GetInstance<TextProcessor2>();
    
                Console.ReadLine();
            }
        }
    
        public static class TextProcessorsCache
        {
            public static ITextProcessor GetInstance<T>() where T : class, ITextProcessor, new()
            {
                return Cache<T>.Get();
            }
        }
    
        static class Cache<T> where T : class, ITextProcessor, new()
        {
            internal static T value;
            static Cache()
            {
                value = new T();
            }
    
            public static T Get()
            {
                return value;
            }
        }
    
        public interface ITextProcessor
        {
        }
    
        public class TextProcessor1 : ITextProcessor
        {
            public TextProcessor1()
            {
                Console.WriteLine("1 constructed");
            }
        }
    
        public class TextProcessor2 : ITextProcessor
        {
            public TextProcessor2()
            {
                Console.WriteLine("2 constructed");
            }
        }
    }
