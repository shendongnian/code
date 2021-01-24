    [ExecuteInEditMode]
    public class CircleSpawn : MonoBehaviour
    {
    	public List<GameObject> Objects;
    	public GameObject OriginalObject;
    	public GameObject PreviousObject;
    	public GameObject ActiveObject;
    	public SpawnData Data;
    
    	private void OnEnable ()
    	{
    		if (Objects == null) Objects = new List<GameObject>();
    
    		// Register modification event
    		Undo.postprocessModifications += OnPropertyModification;
    	}
    
    	private void OnDisable ()
    	{
    		// Deregister modification event
    		Undo.postprocessModifications -= OnPropertyModification;
    	}
    
    	private UndoPropertyModification[] OnPropertyModification (
    			UndoPropertyModification[] modifications)
    	{
    		// Iterate through modifications
    		foreach (var mod in modifications)
    		{
    			var trg = mod.currentValue.target as Component;
    			if (trg)
    			{
    				// Filter only those objects that we've created
    				if (Objects.Contains(trg.gameObject))
    				{
    					// Clone the object and make it 'active'
    					if (!ActiveObject.Equals(trg.gameObject))
    					{
    						SetActiveObj(Instantiate(trg.gameObject));
    						ActiveObject.name = OriginalObject.name;
    						ActiveObject.hideFlags =
    						HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy;
    						ActiveObject.SetActive(false);
    					}
    
    					// Synchronize the other object properties
    					foreach (var obj in Objects)
    					{
    						var type = mod.currentValue.target.GetType();
    						var comp = obj.GetComponent(type);
    						if (comp == null)
    							comp = obj.AddComponent(type);
    
    						EditorUtility.CopySerializedIfDifferent(trg, comp);
    					}
    
    					UpdateTransforms();
    					break;
    				}
    			}
    		}
    
    		return modifications;
    	}
    
    	public void SetActiveObj (GameObject active)
    	{
    		// Destroy the active object
    		if (!OriginalObject.Equals(ActiveObject) &&
    		    !PreviousObject.Equals(ActiveObject))
    			 DestroyImmediate(ActiveObject);
    
    		ActiveObject = active;
    	}
    
    	public void UpdateObjects ()
    	{    
    		// Destroy old objects
    		foreach (var obj in Objects) DestroyImmediate(obj);
    
    		Objects.Clear();
    		var steps = 360.0f / Data.Count;
    		var angle = 0f;
    
    		// Instantiate new objects
    		for (var i = 0; i < Data.Count; i++)
    		{
    			var rot = Quaternion.Euler(0f, 0f, Data.Angle + angle);
    			var pos = rot * Vector3.right * Data.Radius;
    			var obj = Instantiate(ActiveObject, transform.position + pos, rot);
    			obj.SetActive(true);
    			Objects.Add(obj);
    			angle += steps;
    		}
    	}
    
    	public void UpdateTransforms ()
    	{
    		var steps = 360.0f / Objects.Count;
    		var angle = 0f;
    
    		// Set transforms based on Angle and Radius
    		for (var i = 0; i < Objects.Count; i++)
    		{
    			var rot = Quaternion.Euler(0f, 0f, Data.Angle + angle);
    			var pos = rot * Vector3.right * Data.Radius;
    			Objects[i].transform.position =
    			transform.position + pos;
    			Objects[i].transform.rotation = rot;
    			angle += steps;
    		}
    	}
    }
