    private bool extractWriteActions(out List<WriteChannel> channelWrites)
        {
          lock(tpotActionQueue)
          {
            channelWrites = new List<WriteChannel>();
            foreach (TpotAction action in tpotActionQueue)
            {
                if (action is WriteChannel)
                {
                    channelWrites.Add((WriteChannel)action);
                    
                      action.Status = RecordStatus.Batched;
                   
               }
            }
          }
           return (channelWrites.Count > 0);
       }
