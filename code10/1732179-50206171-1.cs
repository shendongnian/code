    public void Start()
    {
        Color = (BallColor)Random.Range(0, Enum.GetNames(typeof(BallColor)).Length - 1)
        GetComponent<SpriteRenderer>().Color = Color.ToColor();
        Ballmanager.SpawnBallsColor.Add(Color);
    }
