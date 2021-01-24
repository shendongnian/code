    using UnityEngine;
    
    public static class Services
    {
    	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    	public static void Initialize()
    	{
    		Debug.Log("test");
    	}
    }
