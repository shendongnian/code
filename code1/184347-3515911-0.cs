    public ObjectCreateStatus AddSchedule(Schedule schedule, out Guid theGuid)
        {
            theGuid = Guid.NewGuid();
            var client = new Services.ConfigurationClient();
            try
            {
                ConfigurationMessage cMsg =
                    client.ConfigService.AddSchedule(
                        this.ControllerBase.SessionVariables.Credentials,
                        schedule
                        );
                if (cMsg.Result == ConfigurationResultEnum.Success)
                    return ObjectCreateStatus.Success;                
                return ObjectCreateStatus.GeneralError;
            }
            finally
            {
                client.Close();
            }
        }
