    public class TrainingSetCardinalityMismatch : ArgumentOutOfRangeException
    {
        public TrainingSetCardinalityMismatch(
                string paramName = "trainingSets", 
                message = "Number of training sets provided must match number of answers provided") 
            : base(paramName, message)
        {
            //code here
        }
    }
