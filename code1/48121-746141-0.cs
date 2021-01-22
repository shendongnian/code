    namespace Programming_CSharp
    {
       using System;
       using System.Diagnostics;
       using System.IO;
       using System.Reflection;
       using System.Reflection.Emit;
       using System.Threading;
     
       // used to benchmark the looping approach
       public class MyMath
       {
          // sum numbers with a loop
          public int DoSumLooping(int initialVal)
          {
             int result = 0;
             for(int i = 1;i <=initialVal;i++)
             {
                result += i;
             }
             return result;
          }
       }
     
       // declare the interface
       public interface IComputer
       {
          int ComputeSum(  );
       }
     
       public class ReflectionTest
       {
          // the private method which emits the assembly
          // using op codes
          private Assembly EmitAssembly(int theValue)
          {
             // Create an assembly name
             AssemblyName assemblyName = 
                new AssemblyName(  );
             assemblyName.Name = "DoSumAssembly";
     
             // Create a new assembly with one module
             AssemblyBuilder newAssembly =
                Thread.GetDomain(  ).DefineDynamicAssembly(
                assemblyName, AssemblyBuilderAccess.Run);
             ModuleBuilder newModule =
                newAssembly.DefineDynamicModule("Sum");
     
             //  Define a public class named "BruteForceSums " 
             //  in the assembly.
             TypeBuilder myType =
                newModule.DefineType(
                "BruteForceSums", TypeAttributes.Public);
     
             // Mark the class as implementing IComputer.
             myType.AddInterfaceImplementation(
                typeof(IComputer));
     
             // Define a method on the type to call. Pass an
             // array that defines the types of the parameters,
             // the type of the return type, the name of the 
             // method, and the method attributes.
             Type[] paramTypes = new Type[0];
             Type returnType = typeof(int);
             MethodBuilder simpleMethod =
                myType.DefineMethod(
                "ComputeSum",
                MethodAttributes.Public | 
                MethodAttributes.Virtual,
                returnType,
                paramTypes);
     
             // Get an ILGenerator. This is used
             // to emit the IL that you want.
             ILGenerator generator = 
                simpleMethod.GetILGenerator(  );
     
             // Emit the IL that you'd get if you 
             // compiled the code example 
             // and then ran ILDasm on the output.
     
             // Push zero onto the stack. For each 'i' 
             // less than 'theValue', 
             // push 'i' onto the stack as a constant
             // add the two values at the top of the stack.
             // The sum is left on the stack.
             generator.Emit(OpCodes.Ldc_I4, 0);
             for (int i = 1; i <= theValue;i++)
             {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
     
             }
     
             // return the value
             generator.Emit(OpCodes.Ret);
     
             //Encapsulate information about the method and
             //provide access to the method's metadata
             MethodInfo computeSumInfo =
                typeof(IComputer).GetMethod("ComputeSum");
     
             // specify the method implementation.
             // Pass in the MethodBuilder that was returned 
             // by calling DefineMethod and the methodInfo 
             // just created
             myType.DefineMethodOverride(simpleMethod, computeSumInfo);
     
             // Create the type.
             myType.CreateType(  );
             return newAssembly;
          }
     
          // check if the interface is null
          // if so, call Setup.
          public double DoSum(int theValue)
          {
             if (theComputer == null)
             {
                GenerateCode(theValue);
             }
     
             // call the method through the interface
             return (theComputer.ComputeSum(  ));
          }
     
          // emit the assembly, create an instance 
          // and get the interface
          public void GenerateCode(int theValue)
          {
             Assembly theAssembly = EmitAssembly(theValue);
             theComputer = (IComputer) 
                theAssembly.CreateInstance("BruteForceSums");
          }
     
          // private member data
          IComputer theComputer = null;
     
       }
     
       public class TestDriver
       {
          public static void Main(  )
          {
             const int val = 2000;  // Note 2,000
     
             // 1 million iterations!
             const int iterations = 1000000;
             double result = 0;
     
             // run the benchmark
             MyMath m = new MyMath(  ); 
             DateTime startTime = DateTime.Now;            
             for (int i = 0;i < iterations;i++)
                result = m.DoSumLooping(val);
             }
             TimeSpan elapsed = 
                DateTime.Now - startTime;
             Console.WriteLine(
                "Sum of ({0}) = {1}",val, result);
             Console.WriteLine(
                "Looping. Elapsed milliseconds: " + 
                elapsed.TotalMilliseconds + 
                " for {0} iterations", iterations);
     
             // run our reflection alternative
             ReflectionTest t = new ReflectionTest(  );
     
             startTime = DateTime.Now; 
             for (int i = 0;i < iterations;i++)
             {
                result = t.DoSum(val);
             }
     
             elapsed = DateTime.Now - startTime;
             Console.WriteLine(
                "Sum of ({0}) = {1}",val, result);
             Console.WriteLine(
                "Brute Force. Elapsed milliseconds: " + 
                elapsed.TotalMilliseconds  + 
                " for {0} iterations", iterations);
          }
       }
    }
     
