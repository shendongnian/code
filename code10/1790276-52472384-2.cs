			Vector3 mousePoint = Camera.main.ViewportToWorldPoint(Input.mousePosition);
			if (objectShouldFollowMouse) {
				objectThatFollowsMouse.transform.position = mousePoint;
				if (Event.current.type == EventType.MouseUp) {
					objectShouldFollowMouse = false;
					objectThatFollowsMouse = null;
				}
			}
			if (prefabGotClicked) {
				GameObject obj = Object.Instantiate(someObject,mousePoint,Quaternion.identity) as GameObject;
				objectShouldFollowMouse = true;
				objectThatFollowsMouse = obj;
			}
