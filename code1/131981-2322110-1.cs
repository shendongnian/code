    class ChocolateMachineActor : Actor
    {
        private void InsertCoinImpl(int value) 
        {
            // whatever...
        }
        public void InsertCoin(int value)
        {
            Submit(() => InsertCoinImpl(value));
        }
    }
