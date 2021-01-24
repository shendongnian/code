    public class test : MonoBehaviour
    {
    	public void CallDestroy ()
    	{
    		StartCoroutine (DestroyThis ());
    	}
    	public IEnumerator DestroyThis ()
    	{
    		yield return new WaitForSeconds (1f);
    		Debug.Log ("Execute after 1 second");
    		gameObject.SetActive (false);
    	}
    }
