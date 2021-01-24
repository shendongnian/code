    var gameObjectName = transform.gameObject.name;
    string[] dObjects = new string[] { "FallingKeule(Clone)", "FallingHeart(Clone)", "FallingCup(Clone)" };
    if(dObjects.Contains(gameObjectName))
    {
        Destroy(transform.gameObject);
    }
    else
    {
        print("You lost a life!");
        Player.GetComponent<Colliding>().Destroy(transform.gameObject);
    }
