    void Update()
    {
        GameObject player1 = GameObject.Find("Player1");
        GameObject player2 = GameObject.Find("Player2");
    
        GameObject enemy1 = GameObject.Find("Enemy1");
        GameObject enemy2 = GameObject.Find("Enemy2");
        GameObject enemy3 = GameObject.Find("Enemy3");
    
        Vector3 newPos = new Vector3(0, 0, 0);
        moveObjects(newPos, 3f, __arglist(player1, player2, enemy1, enemy2, enemy3));
    }
    
    void moveObjects(Vector3 newPos, float duration, __arglist)
    {
        //Put the arguments in ArgIterator
        ArgIterator argIte = new ArgIterator(__arglist);
    
        //Iterate through the arguments in ArgIterator
        while (argIte.GetRemainingCount() > 0)
        {
            TypedReference typedReference = argIte.GetNextArg();
            object tempObj = TypedReference.ToObject(typedReference);
    
            GameObject obj = (GameObject)tempObj;
            //StartCoroutine(moveToNewPos(obj.transform, newPos, duration));
        }
    }
