     public Layer[] layerPriorities =
    {
        Layer.Enemy,
        Layer.Walkable
    };
     [SerializeField] float distanceToBackground = 100f;
    public delegate void OnLayerChange(Layer newLayer); // declare new delegate type
	//lets use event for the protection of the layerchanges
	public event OnLayerChange onlayerChange; // instantiate a observer set
    //Look for and return priority layer hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                raycastHit = hit.Value;
				if(layerHit != layer){ //if layer has changed
					layerHit = layer;
					onlayerChange(layer); //call the delegate
				}
				layerHit = layer;
                return;
            }
        }
        // otherwise return background hit
        raycastHit.distance = distanceToBackground;
		layerHit = Layer.RaycastEndStop;
    }
	//? is a nullable parameter
    RaycastHit? RaycastForLayer(Layer layer)
    {
		/*(Use a bitshift) <<*/
		int layerMask = 1 << (int)layer; // lets do masking formation
		Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; //used as an out parameter
        bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }
