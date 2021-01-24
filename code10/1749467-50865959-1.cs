    public class testTwo: MonoBehaviour
    {
    
    	public void OnCollisionEnter (Collision other)
    	{
    		if (other.transform.CompareTag ("Enemy"))
    		{
    			other.transform.GetComponent<test> ().CallDestroy ();
    			this.gameObject.SetActive (false);
    		}
    	}
    }
