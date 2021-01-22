    // data contract 
    [DataContract]
    public class FormatFault
    {
        private string additionalDetails;
        [DataMember]
        public string AdditionalDetails
        {
            get { return additionalDetails; }
            set { additionalDetails = value; }
        }
    }
    // interface method declaration
        [OperationContract]
        [FaultContract(typeof(FormatFault))]
        void DoWork2();
    // service method implementation
        public void DoWork2()
        {
            try
            {
                int i = int.Parse("Abcd");
            }
            catch (FormatException ex)
            {
                FormatFault fault = new FormatFault();
                fault.AdditionalDetails = ex.Message;
                throw new FaultException<FormatFault>(fault);
            }
        }
    // client calling code
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
