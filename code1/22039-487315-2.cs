        private static void InvokeWCF2()
        {
            ServiceClient service = new ServiceClient();
            try
            {
                service.DoWork2();
            }
            catch (FaultException<FormatFault> e)
            {
                // This is a strongly typed try catch instead of the weakly typed where we need to do -- if (e.Code.Name == "Format_Error")
                Console.WriteLine("Handling format exception: " + e.Detail.AdditionalDetails);   
            }
        }
