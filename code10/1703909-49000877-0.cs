    using System;
    using UnityEngine;
    
    public class USDValueRandomizer : MonoBehaviour {
    
        public float usdValue = 1;
        public float ModifiedUSDValue = 1;
    
        public int MinIntervalTimeInSeconds = 60;
        public int MaxIntervalTimeInSeconds = 300;
    
        public float MinValueModifier = 0.2f;
        public float MaxValueModifier = 0.75f;
    
        private DateTime IntervalStart;
        private int IntervalTimeInSeconds;
        private float ValueModifier;
    
        private void Start()
        {
            RecalculateValue();   
        }
    
        private void FixedUpdate()
        {
            TimeSpan elapsedTime = DateTime.UtcNow - IntervalStart;
    
            if (elapsedTime.Seconds >= IntervalTimeInSeconds)
                RecalculateValue();
    
            ModifiedUSDValue = usdValue * ValueModifier;
        }
    
        private void RecalculateValue()
        {
            IntervalStart = DateTime.UtcNow;
            IntervalTimeInSeconds = Mathf.RoundToInt(UnityEngine.Random.Range(MinIntervalTimeInSeconds, MaxIntervalTimeInSeconds));
            ValueModifier = UnityEngine.Random.Range(0.2f, 0.75f);
        }
    }
