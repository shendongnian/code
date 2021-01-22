    foreach (Animal a in Friends)
    {
      Kangaroo k = a as Kangaroo;
      if (a != null)
      {
        // it's a kangaroo
        k.JumpAround();
      }
      Ostrich o = a as Ostrich;
      if (o != null)
      {
        o.StickHeadInSand();
      }
    }
