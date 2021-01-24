    private void KillSwitch(string accountSid, string authToken)
        {
            TwilioClient.Init(accountSid, authToken);
            var callsInProgress = CallResource.Read(status: CallResource.StatusEnum.InProgress);
            var callsQueued = CallResource.Read(status: CallResource.StatusEnum.Queued);
            var callsRinging = CallResource.Read(status: CallResource.StatusEnum.Ringing);
            foreach (var call in callsQueued)
            {
                CallResource.Update(status: CallResource.UpdateStatusEnum.Completed, pathSid: call.Sid);
            }
            foreach (var call in callsInProgress)
            {
                CallResource.Update(status: CallResource.UpdateStatusEnum.Completed, pathSid: call.Sid);
            }
            foreach (var call in callsRinging)
            {
                CallResource.Update(status: CallResource.UpdateStatusEnum.Completed, pathSid: call.Sid);
            }
        }
