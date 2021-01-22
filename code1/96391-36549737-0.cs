      internal class ShouldRetryHandler {
        private static int RETRIES_MAX_NUMBER = 3;
        private static int numberTryes;
        public static bool shouldRetry() {
            var statusRetry = false;
            if (numberTryes< RETRIES_MAX_NUMBER) {
                numberTryes++;
                statusRetry = true;
                //log msg -> 'retry number' + numberTryes
            
            }
            else {
                statusRetry = false;
                //log msg -> 'reached retry number limit' 
            }
            return statusRetry;
        }
    }
