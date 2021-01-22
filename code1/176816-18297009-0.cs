	public Dictionary<string, int> myDictionary = new Dictionary<string, int>();
	public string myCurrentKey = "some key 5";
	for (int i = 1; i <= 10; i++) {
		myDictionary.Add(string.Format("some key {0}", i), i);
	}
	
	private void MoveIndex(int dir) { // param "dir" can be 1 or -1 to move index forward or backward
		List<string> keys = new List<string>(myDictionary.Keys);
		int newIndex = keys.IndexOf(myCurrentKey) - dir;
		if (newIndex < 0) {
			newIndex = myDictionary.Count - 1;
		} else if (newIndex > myDictionary.Count - 1) {
			newIndex = 0;
		}
		
		myCurrentKey = keys[newIndex];
	}
	
	Debug.Log(string.Format("Current value: {0}", myDictionary[myCurrentKey])); // prints 5
	MoveIndex(1);
	Debug.Log(string.Format("Current value: {0}", myDictionary[myCurrentKey])); // prints 6
	MoveIndex(-1);
	MoveIndex(-1);
	Debug.Log(string.Format("Current value: {0}", myDictionary[myCurrentKey])); // prints 4
