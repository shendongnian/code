    public void OnPostUpdate(PostUpdateEvent postUpdateEvent)
    {
       var dirtyProperties = postUpdateEvent.Persister.FindDirty(postUpdateEvent.State, postUpdateEvent.OldState, postUpdateEvent.Entity, postUpdateEvent.Session);
       int dirty = dirtyProperties.Length;
    
       if (dirty == 0) // I want detect only modififed entities
          return;
       Trace.WriteLine(string.Format("OnPostUpdate({0}, {3}) in session#{1} - dirty props. {2}", postUpdateEvent.Entity.GetType().Name, postUpdateEvent.Session.GetHashCode(), dirty, postUpdateEvent.Entity.GetHashCode()));
       lock (_objects)
       {
         if (!_objects.Contains(postUpdateEvent.Entity)) // I will manipulate this list in `AbstractFlushingEventListener.PostFlush` method
            _objects.Add(postUpdateEvent.Entity);
       }
     }
