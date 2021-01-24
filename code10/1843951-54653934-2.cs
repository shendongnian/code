    public List<GameObject> enemys;
	List<GameObject> enemysToRemove = new List<GameObject>();
	void Update () {
		foreach(GameObject enemy in enemys){
			if (enemy == null) {
				enemysToRemove.Add (enemy);
			}
		}
		foreach (GameObject item in enemysToRemove) {
			enemys.Remove (item);
		}
	}
