    if (newPreviousValue.Contains("B"))
    {
         if (result.Equals("T"))
         {
               tieCounterBanker++;
               Debug.Log("TIE FOR BANKER : " + tieCounterBanker);
         }
         else
         {
               tieCounterBanker = 0;
         }
    }
    else if(newPreviousValue.Contains("P"))
    {
          if (result.Equals("T"))
          {
                tieCounterPlayer++;
                Debug.Log("TIE FOR PLAYER : " + tieCounterPlayer);
          }
          else
          {
                tieCounterPlayer = 0;
          }
    }
