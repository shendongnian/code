    public class LongProcessRunner<T>
    {
        private Func<T> longProcess;
        public LongProcessRunner(Func<T> longProcess)
        {
            this.longProcess = longProcess;
        }
        public T RunAndReturn(int numberOfTimes)
        {
            for (var i = 0; i < numberOfTimes; i++)
            {
                //connect to db
                var processResult = longProcess();
                //Save results
            }
            //versioning & rest 
            //return stuff
            var processRunner = new LongProcessRunner(() => MyFunctionWithoutParameter());
        }
    }
