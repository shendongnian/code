    for (int i=0; i<tpotActionQueue.Count(); i++)
    {
        TpotAction action = tpotActionQueue.Dequeue();
        if (action is WriteChannel)
        {
            channelWrites.Add((WriteChannel)action);
            lock(tpotActionQueue)
            {
                action.Status = RecordStatus.Batched;
            }
        }
    }
