    using UnityEngine;
    
    public class RandomTest : MonoBehaviour
    {    
        private const int TestRuns = 1000000;
        private const int Probability = 1;
    
    	// Use this for initialization
    	void Start ()
    	{
    	    int hits = 0;
    
    	    for (int i = 0; i < TestRuns; i++)
    	    {
    	        int randomValue = Random.Range(0, 100);
    	        if (randomValue < Probability)
    	        {
    	            hits++;
    	        }
    	    }
    
    	    float probability = (float) hits / TestRuns * 100;
    
            Debug.Log("Outcome: " + probability.ToString("f4") + " %");
    	}
    }
