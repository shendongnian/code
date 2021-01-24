    private bool travelInLinearPath = true;
    
    private void OnEnable ( )
    {
        EnemySpawner.EnemySpawning -= OnEnemySpawning;
        EnemySpawner.EnemySpawning += OnEnemySpawning;
        travelInLinearPath = true;
    }
    
    public void OnEnemySpawning( )
    {
        EnemySpawner.EnemySpawning-= OnEnemySpawning;
        travelInLinearPath = false;
    }
    
    private void Update ( )
    {
        if ( travelInLinearPath )
            enemy.transform.Translate ( Vector3.forward * speed * Time.deltaTime );
        else
            enemy.GetComponent<Rigidbody> ( ).velocity = Vector3.forward * 5 + Vector3.left * 3 * Mathf.Sin ( 10f * Time.time );
    }
