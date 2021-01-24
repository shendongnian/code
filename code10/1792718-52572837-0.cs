    internal class CollisionTrigger : MonoBehaviour
    {
    	private bool _isPlayerInsideTrigger = false;
    	
    	private void Update()
    	{
    		if(_isPlayerInsideTrigger)
    		{
    			FakeOnTriggerStay();
    		}
    	}
    	
    	private void OnTriggerEnter(Collider collider)
    	{
    		if(!collider.CompareTag("Player") return;
    		_isPlayerInsideTrigger = true;
    	}
    	
    	public abstract void FakeOnTriggerStay();
    	
    	private void OnTriggerExit(Collider collider)
    	{
    		if(!collider.CompareTag("Player") return;
    		_isPlayerInsideTrigger = false;
    	}
    }
