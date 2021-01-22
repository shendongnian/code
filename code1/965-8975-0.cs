    Mode = Mode.Read;
    //Add Mode.Write
    Mode |= Mode.Write;
    Assert.True(((Mode & Mode.Write) == Mode.Write)
      && ((Mode & Mode.Read) == Mode.Read)));
