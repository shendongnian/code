    public override Start()
    {
      do
      {
        if(EnemyToTheLeft())
        {
          TurnLeft(90); // this will call Yield and return when we have finished turning
          Shoot();
        }
        Yield(); // always yield
      }while(!dead);
    }
