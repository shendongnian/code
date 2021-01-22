    switch (ReadDecision)
     {
      case ReadDecisions.ReadNext:
       {
        Message = queue.Receive(Timeout);
        break;
       }
      case ReadDecisions.PeekNext:
       {
        Message = queue.Peek(Timeout);
        break;
       }
      case ReadDecisions.ReadMessageId:
       {
        Message = queue.ReceiveById(Id, Timeout);
        break;
       }
      case ReadDecisions.PeekMessageId:
       {
        Message = queue.PeekById(Id, Timeout);
        break;
       }
      case ReadDecisions.ReadCorrelationId:
       {
        Message = queue.ReceiveByCorrelationId(Id, Timeout);
        break;
       }
      case ReadDecisions.PeekCorrelationId:
       {
        Message = queue.PeekByCorrelationId(Id, Timeout);
        break;
       }
      default:
       {
        throw new Exception("Unknown ReadDecisions provided");
       }
      }
