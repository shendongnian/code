    [Constructable]
    public Spawner(params string[] creatureName ) : base( 0x1f13 )
    {
        InitSpawn( 1, TimeSpan.FromMinutes( 5 ), TimeSpan.FromMinutes( 10 ), 0, 4, creaturesName.ToList() );
    }
