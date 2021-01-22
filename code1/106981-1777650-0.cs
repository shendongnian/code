    using System.ServiceModel;
    namespace AdditionServiceNamespace
    {
        [DataContract]
        public class Complex
        {
            [DataMember]
            public int real;
            [DataMember]
            public int imag;
        }
        [ServiceContract]
        public interface IAdditionService
        {
            [OperationContract]
            Complex Add(Complex c1, Complex c2);
        }
        public class AdditionService : IAdditionService
        {
            public Complex Add(Complex c1, Complex c2)
            {
                Complex result = new Complex();
                result.real = c1.real + c2.real;
                result.imag = c1.imag + c2.imag;
                return result;
            }
        }
    }
