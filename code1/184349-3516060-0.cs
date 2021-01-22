    public class ObjectCreateStatus {
      public bool WasSuccessful { get; private set; }
      public Guid ScheduleId { get; private set; }
    
      ctor(ConfigurationResultEnum result, Guid guid) {
        WasSuccessful = result == ConfigurationResultEnum.Success;
        ScheduleId = guid
      }
    }
    public ObjectCreateStatus AddSchedule(Schedule schedule)
    {
        var client = new Services.ConfigurationClient();
        try
        {
            ConfigurationMessage cMsg =
                client.ConfigService.AddSchedule(
                    this.ControllerBase.SessionVariables.Credentials,
                    schedule
                    );
            return new ObjectCreateStatus(cMsg.Result, cMsg.Guid(?))
        }
        finally
        {
            client.Close();
        }
    }
