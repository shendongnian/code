            [ErrorHandlerBehavior]
            public class Service1 : IService1
            {
               public TestMethod1Ouput TestMethod1(TestMethod1Input input)
               {
                   if (input.Throws)
                   {
                       throw new Exception("a error message 1");
                   }
                   return new TestMethod1Ouput { OrginalResult = 123 };
               }
    
               public TestMethod2Ouput TestMethod2(TestMethod2Input input)
               {
                   if (input.Throws)
                   {
                       throw new Exception("a error message 2");
                   }
                   return new TestMethod2Ouput { OrginalResult = "?"};
               }
           }
    
           [ServiceContract]
           [DataContractOperationResult]
           public interface IService1
           {
               [OperationContract]
               [FaultContract(typeof(OperationResult<int>))]
               TestMethod1Ouput TestMethod1(TestMethod1Input input);
    
               [OperationContract]
               [FaultContract(typeof(OperationResult<string>))]
               TestMethod2Ouput TestMethod2(TestMethod2Input input);
           }
    
           public interface IOperationResult
           {
               string Error { get; set; }
           }
    
           public interface IOperationResult<TResult> : IOperationResult
          {
               TResult Result { get; set; }
           }
    
           [DataContract]
           public class OperationResult : IOperationResult
           {
               [DataMember(Name = "Error")]
               public string Error { get; set; }
           }
    
           [DataContract]
           public class OperationResult<TResult> : OperationResult, IOperationResult<TResult>, IOperationResult
           {
               [DataMember(Name = "Result")]
               public TResult Result { get; set; }
           }
    
           public class TestMethod1Ouput
           {
               public int OrginalResult { get; set; }
           }
    
           public class TestMethod1Input
           {
               public bool Throws { get; set; }
           }
    
           public class TestMethod2Ouput
           {
               public string OrginalResult { get; set; }
           }
    
           public class TestMethod2Input
           {
               public bool Throws { get; set; }
           }
