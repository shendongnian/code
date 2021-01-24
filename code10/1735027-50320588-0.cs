		if(Physics.Raycast(ray, out hit))
		{
			if (hit.collider.name.Contains("Hex"))
			{
				hovering=hit.collider.gameObject;
				foreach(KeyValuePair<GameObject,Hex> h in HexData){
					if (h.Key==hovering){
						highlightNeighbors(true,h.Value);
						h.Value.hovering=true;
					}
					else if(h.Key!=hovering && h.Value.hovering==true){
						highlightNeighbors(false,h.Value);
						h.Value.hovering=false;
					}
					
				}
			}
		}
		else{
			if (hovering){
				hovering=null;
			}
		}
