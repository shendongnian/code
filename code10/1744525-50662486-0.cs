        //-----------------------------------------------------------------------------
    	// getObjsWithMat
    	//-----------------------------------------------------------------------------
    	public static int getObjsWithMat (Material mat) {
            Material m_DefaultMat = mat;
    		int m_c = 0;
            
    		GameObject[] AllObjs = Object.FindObjectsOfType<GameObject> ();
    		foreach (GameObject Obj in AllObjs) {
    			if (Obj.activeInHierarchy) {
    				if (Obj.GetComponent <Renderer> ()) {
    					foreach (Material Mat in Obj.GetComponent <Renderer> ().sharedMaterials) {
    						if (Mat == m_DefaultMat)
    							m_c++;
    					}
    				}
    			}
    		}
    
    		return m_c;
    	}
