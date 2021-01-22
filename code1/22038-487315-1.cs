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
