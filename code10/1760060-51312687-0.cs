    float delaytimer;
    void Update () {
        delaytimer += Time.deltaTime;
        population = GameObject.FindGameObjectsWithTag("NPCobject");
        if (delaytimer > 1) // time to wait 
        {
            for (int i = 0; i < population.Length; i++)
            {
                getNewPosition();
                if (population[i].transform.position != pos)
                {
                    population[i].transform.position = Vector3.MoveTowards(population[i].transform.position, pos, .1f);
                }
    
            }
            delaytimer = 0f; // reset timer
        }
    }
    void getNewPosition()
    {
        float x = Random.Range(-22, 22);
        float z= Random.Range(-22, 22);
    
        pos = new Vector3(x, 0, z);
    }
