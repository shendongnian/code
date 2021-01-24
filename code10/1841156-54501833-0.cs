    using System.Collections;
    using UnityEngine;
    
    
    public class Cannon : MonoBehaviour {
    
    	[SerializeField] private GameObject _cannonballPrefab;
    	
    
    	private IEnumerator Start () {
    		yield return new WaitForSeconds (2);
    		Instantiate (_cannonballPrefab);
    	}
    }
