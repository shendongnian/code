    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;
    namespace ConsoleApplication1
    {
        public static class Program
        {
            private static Type CreateType()
            {
                SyntaxTree tree = SyntaxTree.ParseText(
                    @"using System;
 
                    namespace Foo
                    {
                        public class Bar
                        {
                            public static void Test()
                            {
                                Console.WriteLine(""Hello World!"");
                            }
                        }
                    }");
                var compilation = Compilation.Create("Hello")
                    .WithOptions(new CompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                    .AddReferences(MetadataReference.CreateAssemblyReference("mscorlib"))
                    .AddSyntaxTrees(tree);
                ModuleBuilder helloModuleBuilder = AppDomain.CurrentDomain
                    .DefineDynamicAssembly(new AssemblyName("FooAssembly"), AssemblyBuilderAccess.RunAndCollect)
                    .DefineDynamicModule("FooModule");
                var result = compilation.Emit(helloModuleBuilder);
                return helloModuleBuilder.GetType("Foo.Bar");
            }
            static void Main(string[] args)
            {
                Type fooType = CreateType();
                MethodInfo testMethod = fooType.GetMethod("Test");
                testMethod.Invoke(null, null);
                WeakReference weak = new WeakReference(fooType);
                fooType = null;
                testMethod = null;
                Console.WriteLine("type = " + weak.Target);
                GC.Collect();
                Console.WriteLine("type = " + weak.Target);
                Console.ReadKey();
            }
        }
    }
