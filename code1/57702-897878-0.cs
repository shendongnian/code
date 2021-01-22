    [assembly: CLSCompliant(true)]
    namespace MyNamespace
    {
        public class Sample : ISample, ISample2
        {
            void ISample.MyMethod(ref int[] array)
            {
            }
            void ISample2.MyMethod(int[] array)
            {
            }
        }
        public interface ISample
        {
            void MyMethod(ref int[] array);
        }
        public interface ISample2
        {
            void MyMethod(int[] array);
        }
    }
