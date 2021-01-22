    CompilerResults results2 = provider2.CompileAssemblyFromSource(parameters, @"
    namespace Dynamic
    {
        public class B : A
        {
        }
    }
    ");
