            private OperationResult GetData()
            {
                List<int> theData = new List<int>();
                try
                {
                    theData = ProcessThatGetsData(); //Error occurs in here
                    return new OperationResult { Success = true, Data = theData };
                }
                catch (Exception exc)
                {
                    return new OperationResult { Success = false };
                }
                return theData;  //What should be returned here?
            }
    
            public class OperationResult
            {
                public bool Success { get; set; }
                public IList<int> Data { get; set; }
            }
