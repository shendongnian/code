    [HttpPost]
            public ActionResult AddCallLog(string callId,string type,int entityId)
            {
                TwilioClient.Init(_callSetting.Twilio.AccountSid, _callSetting.Twilio.Authtoken);
    
              
                var records = CallResource.Read(parentCallSid: callId).ToList();
                if (records.Any())
                {
    
                    var callResource= records[0];
                    var parentRecord = CallResource.Fetch(pathSid: callId);
                    if (callResource.Status.ToString().Equals("completed", StringComparison.OrdinalIgnoreCase))
                    {
                        CallRecord callRecord = new CallRecord
                        {
                            EntityKey = entityId,
                            EntityType = type,
                            CallDateTimeUtc = callResource.DateCreated ?? DateTime.UtcNow,
                            CallSId = callResource.Sid,
                            ParentCallSId = callResource.ParentCallSid,
                            CalledById = _operatingUser.Id,
                            DurationInSeconds = parentRecord==null? Convert.ToDouble(callResource.Duration): Convert.ToDouble(parentRecord.Duration),
                            ToPhone = callResource.To,
                            CompanyId = _operatingUser.CompanyId
                        };
                         var callRecordResult=   _callRecordService.Add(callRecord);
                        var recording = RecordingResource.Read(callSid: callId).ToList();
                        if (!recording.Any()) return Json(true);
                        foreach (RecordingResource recordingResource in recording)
                        {
                            using (var client = new WebClient())
                            {
                                var url =
                                    "https://api.twilio.com" + recordingResource.Uri.Replace(".json", ".mp3");
                                var content = client.DownloadData(url);
    
                                CallRecordMedia callRecordMedia = new CallRecordMedia
                                {
                                    CallRecordId = callRecordResult.Id,
                                    ContentType = "audio/mpeg",
                                    RecordingSId = recordingResource.Sid,
                                    RecordingCallSId = recordingResource.CallSid,
                                    FileType = "mp3",
                                    Data = content,
                                    Price = Convert.ToDouble(recordingResource.Price),
                                    PriceUnit = recordingResource.PriceUnit,
                                    DurationInSeconds = Convert.ToDouble(recordingResource.Duration)
                                };
                                _callRecordService.AddCallRecording(callRecordMedia);
                            }
                        }
                    }
                }
               return Json(true);
            }
