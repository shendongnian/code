    public class PlayerScript : MonoBehaviour 
	{
		//The update frame
		private void Update()
		{
            //If player has lost
			if(heart.count.Equals(0))
			{
				ShowAd();
			}
		}
		//A funtion which shows ad
		private void ShowAd()
		{
			//Whichever ad provider you use; use the funtion
		}
	}
