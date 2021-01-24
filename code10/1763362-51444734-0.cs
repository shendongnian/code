    public int countTrial = 0;
    public int maxTrials = 16;
    public Spawner spawner;
    
    List<int> trialMarkers = new List<int>() {1, 1, 2, 2, 3};
    
        public void chooseNextTrial()
        {
            
                Debug.Log(countTrial + ": " + trialMarkers[countTrial]);
                if (trialMarkers[countTrial] == 1)
                {
                    spawner.startTrialWithFixedValue1();
                }
                if (trialMarkers[countTrial] == 2)
                {
                    spawner.startTrialWithFixedValue2();
                }
                else
                {
                    spawner.startTrialWithRandomValue();
                }
          }
