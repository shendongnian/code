            var client = new ServiceReference1.Service1Client();
            WcfService1.OperationResult<int> resultOk1 = client.TestMethod1(new WcfService1.TestMethod1Input { Throws = false });
            WcfService1.OperationResult<string> resultOk2 = client.TestMethod2(new WcfService1.TestMethod2Input { Throws = false });
            WcfService1.IOperationResult resultKo1;
            WcfService1.OperationResult resultKo2;
            try
            {
                resultOk1 = client.TestMethod1(new WcfService1.TestMethod1Input { Throws = true });
            }
            catch (FaultException<WcfService1.OperationResult<int>> ex)
            {
                resultKo1 = ex.Detail;
            }
            try
            {
                resultOk2 = client.TestMethod2(new WcfService1.TestMethod2Input { Throws = true });
            }
            catch (FaultException<WcfService1.OperationResult<string>> ex)
            {
                resultKo2 = ex.Detail;
            }
