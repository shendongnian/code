    switch (resultType)
    {
        case (ResultType.Song):
          factory = new SongResultFactory();
          template = factory.BuildResult();
          break;
        // ...
