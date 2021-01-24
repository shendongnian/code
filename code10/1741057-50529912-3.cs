    var gameObjectName = transform.gameObject.name;
    if(gameObjectName == "FallingKeule(Clone)" || gameObjectName == "FallingHeart(Clone)" || gameObjectName == "FallingCup(Clone)")
    {
        Destroy(transform.gameObject);
    }
    else
    {
        print("You lost a life!");
        Player.GetComponent<Colliding>().Destroy(transform.gameObject);
    }
