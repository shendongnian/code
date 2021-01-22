        public void processStuff()
        {
            Status returnStatus = Status.Success;
            try
            {
                if (!performStep1())
                    returnStatus = Status.Error;
                else if (!performStep2())
                    returnStatus = Status.Warning;
                //.. More steps, some of which could change returnStatus..//
                else if (!performStep3())
                    returnStatus = Status.Error;
            }
            catch (Exception ex)
            {
                log(ex);
                returnStatus = Status.Error;
            }
            finally
            {
                //some necessary cleanup
            }
            // Do your FinalProcessing(returnStatus);
            return returnStatus;
        }
