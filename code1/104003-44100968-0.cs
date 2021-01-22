    // ----- Assume that spaceItem is of type SpaceType,
    //       and that Planet and Star derive from SpaceType.
    switch (spaceItem)
    {
      case Planet p:
        if (p.Type != PlanetType.GasGiant)
          LandSpacecraft(p);
        break;
      case Star s:
        AvoidHeatSource(s);
        break;
      case null:
        // ----- If spaceItem is null, processing falls here,
        //       even if it is a Planet or Star null instance.
        break;
      default:
        // ----- Anything else that is not Planet, Star, or null.
        break;
    }
