    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
 
    public static class MyExtensions
    {
        public static IMyImplementation Implementation = new MyImplementation();
 
        public static string MyMethod(this object obj)
        {
            return Implementation.MyMethod(obj);
        }
    }
 
    public interface IMyImplementation
    {
        string MyMethod(object obj);
    }
 
    public class MyImplementation : IMyImplementation
    {
        public string MyMethod(object obj)
        {
            return "Hello World!";
        }
    }
 
