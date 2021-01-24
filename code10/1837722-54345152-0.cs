    private int lastSpawnPos;
	[SerializeField]
	private Transform[] spawnPos;
	//Your arrow 
	public GameObject Arrow;
	//Player
	public Transform Player;
	//Storing all spawned cops
	public List<Transform> Cops;
	
	void SpawnPoliceCar()
	{
		GameObject policeCar = ObjectPooling.instance.GetPooledObject("PoliceCar");
		int r = UnityEngine.Random.Range(0, spawnPos.Length);
		//Adding cop to the list when spawned
		//TODO: do not forget to remove from the list, when cop is removed (back to the pool)
		Cops.Add(policeCar.transform);
		
		while (lastSpawnPos == r)
		{
			r = UnityEngine.Random.Range(0, spawnPos.Length);
		}
		Vector3 policeCarPos = policeCar.transform.position;
		policeCarPos = new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z);
		policeCar.SetActive(true);
		policeCar.GetComponent<Damage>().DefaultSetting();
		lastSpawnPos = r;
		currentPoliceCar++;	
	}
	//Call this on update
	void PointArrow()
	{
		Transform farthestCop = null;
		float maxDistance = 0.0f;
		//Find the farthes cop
		foreach (var cop in Cops)
		{
			var distance = Vector3.Distance(Player.position, cop.position);
			if (distance > maxDistance)
			{
				farthestCop = cop;
				maxDistance = distance;
			}
		}
		//If there are no cops - can't point an arrow
		if(farthestCop == null) return;
		//Point an arrow on the cop
		Arrow.transform.LookAt(farthestCop);
	}
