    if (Input.touchCount > 0) {
		AZone = 0;
		BZone = 0;
		//Debug.Log (Input.touchCount);
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).position.x > 0 && Input.GetTouch (i).position.x < Screen.width / 4) {
				AZone += 1;
				if (AZone == 1) {
					transform.Rotate (Vector3.forward * 300f * Time.deltaTime);
				}
				//Debug.Log (AZone);
			}
			if (Input.GetTouch (i).position.x > Screen.width / 4 && Input.GetTouch (i).position.x < Screen.width / 2) {
				BZone += 1;
				if (BZone == 1) {
					transform.Rotate (Vector3.back * 300f * Time.deltaTime);
				}
			}
		}
	}
