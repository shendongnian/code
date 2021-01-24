    using UnityEngine;
    
    [RequireComponent(typeof(SphereCollider))]
    internal abstract class CollisionTrigger : MonoBehaviour
    {
        private bool _isPlayerInsideTrigger = false;
    	
    	private void Awake()
    	{
    		if(!GetComponent<SphereCollider>().isTrigger)
    		{
    			Debug.LogError("Please set the sphere collider to a trigger.");
    			enabled = false;
    			return;
    		}
    	}
    	
        private void Update()
        {
            if(_isPlayerInsideTrigger)
            {
                FakeOnTriggerStay();
            }
        }
    
        private void OnTriggerEnter(Collider collider)
        {
            if(!collider.CompareTag("Player")) return;
            _isPlayerInsideTrigger = true;
        }
    
        public abstract void FakeOnTriggerStay();
    
        private void OnTriggerExit(Collider collider)
        {
            if(!collider.CompareTag("Player")) return;
            _isPlayerInsideTrigger = false;
        }
    }
