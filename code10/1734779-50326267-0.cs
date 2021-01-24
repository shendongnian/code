    using UnityEngine;
    
    public class RateCounter : MonoBehaviour
    {
      
        [SerializeField]  float timeooutValue = 3;
        [SerializeField] float startTime;
        [SerializeField] int counter;
        [SerializeField] float currentRate;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time - startTime > timeooutValue)
                {
                    startTime = Time.time;
                    counter = 0;
                    currentRate = 0;
                }
                else
    
                {
                    counter++;
                    currentRate=counter/(Time.time-startTime);
                }
    
            }
    
        }
    
    }
