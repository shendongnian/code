namespace System.Numerics
{
    class MyClass
    {
    }
}
namespace UnityEngine
{
    class MyClass
    {
    }
}
using System.Numeric;
namespace ConsoleApplication24
{
    using UnityEngine; // inside the namespace
    class Program
    {
        static void Main(string[] args)
        {
            MyClass xx = new MyClass(); // from UnitEngine instead of System.Numeric
        }
    }
}
