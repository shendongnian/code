    for(int i = 0; i < tpotActionQueue.Length; i++)
    {
         TpotAction action = tpotActionQueue[i];
         if (action is WriteChannel)
         {
            channelWrites.Add((WriteChannel)action);
            lock(tpotActionQueue)
            {
               action.Status = RecordStatus.Batched;
            }
         }
    }
