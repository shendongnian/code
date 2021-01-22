     public List<ProjektyEntity> GetProjekty()
       {
          try
          {
             return this.channel.GetProjekty();
           }
           catch (EndpointNotFoundException exception)
           {
              'Write here Some Clean Up Codes
              ' Log it somewhere on your server so that you can fix the error
           }
        }
