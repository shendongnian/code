    IEnumerator SpawnBarrier(){
        spawnCount=0
        yield return new WaitForSeconds (3f);
        while (true) {
            for(int i=0;i<=4;i++)
            {
                spawning.Add (Instantiate (barrier, positions [i],   Quaternion.identity)as GameObject);
            }
            if (++spawnCount==10)
            {
                break;
            }
            yield return new WaitForSeconds (3f);
        }
    }
