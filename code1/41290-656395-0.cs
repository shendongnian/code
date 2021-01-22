    public void Ahead(int pix)
    {
      moving = true;
      distanceToMove = pix;
      pixFromLastMove = 0;
      velocity = new Vector2((float) Math.Cos(rotation), (float) Math.Sin(rotation))*5.0f;
      //DO NOT RETURN UNTIL THIS ROBOT HAS MOVED TO ITS DESTINATION
      while(!HasReachedDestination())
      {
        Yield(); // let another fiber run
      }
    }
