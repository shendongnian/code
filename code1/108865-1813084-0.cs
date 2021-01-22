      public T TrackInstantiation<T>(T entity)
      {
        Log.BeginRequest(entity, ActionType.Create); 
        Validate(entity);
        WebService.Send(Convert(entity));
        Log.EndRequest(entity, ActionType.Create);
      }
