    using UnityEngine;
    
    public class RaceCarMovement : MonoBehaviour {
        
        float drivespeed = 0.3f;
        private AudioSource CarEngine;
    
        private void Awake()
        {
            CarEngine = GetComponent<AudioSource>();
        }
    
        void Start () 
        {
            
        }
    
        void Update()
        {
            if (Input.GetKey("up"))
            {
                transform.position = new Vector3(transform.position.x + drivespeed, transform.position.y);
                PlayCarSound(true);
            }
    
            else if (Input.GetKey("down"))
            {
                transform.position = new Vector3(transform.position.x - drivespeed, transform.position.y);
                PlayCarSound(true);
            }
    
            else if (Input.GetKey("left"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + drivespeed);
                PlayCarSound(true);
            }
    
            else if (Input.GetKey("right"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - drivespeed);
                PlayCarSound(true);
            }
            
            else
            {
                PlayCarSound(false);
            }
        }
        
        private void PlayCarSound(bool play)
        {
            if(play /*&& !CarEngine.isPlaying*/) CarEngine.Play();
            else CarEngine.Stop();
        }
    }
