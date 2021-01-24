    public class PlayerScript : MonoBehaviour 
    {
        public bool Lose = false;
        
        void Update()
        {
           if(health <= 0);//believing your player loses when his health is zero, it would have been better if you provided all the scripts
           {
               Lose = true;
           }
           if(Lose) // if lose is true
           {
                interstitial.Show (); //show the ad
           } 
        }        
        
