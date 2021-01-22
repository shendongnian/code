    Queue<MatchUpdateQueue> waiting = new Queue<MatchUpdateQueue>();
    events.WriteEntry("matchqueue worker thread started");
    while (!stop)
    {
        using (var db = new aDataContext())
        {
          if (waiting.Count == 0)
          {
            /* grab any new items available */
               List<MatchUpdateQueue> freshitems = db.MatchUpdateQueues
                                                     .OrderBy(item => item.id)
                                                     .ToList();
               foreach (MatchUpdateQueue item in freshitems)
                    waiting.Enqueue(item);
          }
          ...
       }
    }
