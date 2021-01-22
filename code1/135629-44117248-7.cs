        public class LongOperationManager: ILongOperationCallBack
        {
            public busy StartLongOperation(ILongOperationService server, ....)
            {
                //here you can make the method async using a TaskCompletionSource
                if(server.StartLongOperation(...)) Console.WriteLine("long oper started");
                else Console.Writeline("Long Operation Server is busy")
            }
            public void OnResultsSend(.....)
            {
                ... use long operation results..
                //Complete the TaskCompletionSource if you used one
            }
        }
