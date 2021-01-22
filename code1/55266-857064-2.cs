    public class MyService : IMyServiceContract 
    {
        public void MyOperation()
        {
            if (somethingWentWrong)
            {
                var faultContract = new NoRoomsAvailableFaultContract()
                {
                    Message = "ERROR MESSAGE"
                };
                throw new FaultException<NoRoomsAvailableFaultContract>(faultContract);
            }
        }
    }
