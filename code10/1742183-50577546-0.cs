    private Dictionary<string, GameObject> prefabs;
    // Use this for initialization
	void Start () {
	    var sword = (GameObject) Resources.Load("Weapons/sword", typeof(GameObject));
	    prefabs.Add("sword", sword);
        // Add other prefabs
	};
    void OnTriggerEnter2D(Collider2D other)
    {
        if (prefabs.ContainsKey(other.tag))
            Instantiate(prefabs[other.tag]);
    }
