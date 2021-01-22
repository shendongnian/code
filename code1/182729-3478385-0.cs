    Scenario
    {
      IDictionary<int, float> cache = new Dictionary<int, float>;
      void Reset()
      {
        cache.Clear();
      }
    }
    PhysicsScenario : Scenario
    {
      const int AccelerationType = 1; // or string, or whatever. Just needs to be a key into the cache.
      float[] CalculateAcceleration() 
      {
         if (cache.Keys.Contains(AccelerationType))
         {
           return cache[AccelerationType];
         }
         else
         {
           float[] values = ActualCalculateAcceleration();
           cache.Add(AccelerationType, values);
           return values;
         }
      }
      float[] CalculateVelocity() {...} 
      // More heavy calculations
    }
    ChemistryScenario : Scenario
    {
      float[] CalculateVolume() {...}
      float[] CalculateCalorificValue() {...}
      // More heavy calculations
    }
