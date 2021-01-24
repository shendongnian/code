    private void SpawnCoin()
    {
         coinSpawn = Random.Range(1, 5);
         float x = 1.0f;
         for (int i = 0; i < coinSpawn; i++)
         {
             spawnCoin = Instantiate(coin) as GameObject;
             spawnCoin.transform.SetParent(transform);
             float currentPos = spawnCoin.transform.position.x;
             spawnCoin.transform.Translate(currentPos+x, -0.1f, -1f);
             x+=1.0f;
         }
}
