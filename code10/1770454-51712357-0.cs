    public GameObject enemyPrefab;
    //runs every frame, to check for the key press in this case
	public void Update ()
	{
		//did we press the specified key? (C)
		if (Input.GetKeyDown(KeyCode.C))
		{
			//call our method to create our enemies!
			CreateEnemies(20);
		}
	}    
    public void CreateEnemies (int enemies)
	{
        //the amount of enemies we want to have
        //run through this loop until we hit the amount of enemies we want
		for (int i = 0; i < enemies; i++)
		{
            //create the new enemy based on the provided prefab
			Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
		}
	}
