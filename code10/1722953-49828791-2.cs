    jarray = JsonConvert.DeserializeObject<AppointmentReasonResponse>(json);
    foreach (AppointmentReason ApptReason in jarray.AppointmentReasonList)
    {
        foreach (ReasonCode Reason in ApptReason.ReasonCodeList)
        {
            AddInterfacePMReasonCode(PracticeID, Reason.Code, Reason.Description);
        }
    }
