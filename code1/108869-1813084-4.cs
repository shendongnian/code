      public ICanBeTracked TrackInstantiation(ICanBeTracked  entity)
      {
        Log.BeginRequest(entity, ActionType.Create); 
        Validate(entity);
        WebService.Send(Convert(entity));
        Log.EndRequest(entity, ActionType.Create);
        // Don't you also need to return the thing to fulfill the method siugnature ?
        return entity;
      }
