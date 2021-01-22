    class Person
    {
      // A Person should be able to Feed
      // another Entity, but they way he feeds
      // each is different
      public override void Feed( Entity e )
      {
        if( e is Person )
        {
          // feed me
        }
        else if( e is Animal )
        {
          // ruff
        }
      }
    }
