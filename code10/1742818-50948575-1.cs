    ublic void ParseMessage(string messagePdu)
        {
            SMSType smsType = SmsBase.GetSMSType(messagePdu);
            switch (smsType)
            {
                case SMSType.SMS:
                    Sms sms = new Sms();
                    Sms.Fetch(sms, ref messagePdu);
                    string messageBody = sms.Message;
                    string phoneNumber = sms.PhoneNumber;
                    DateTime messageDateTime = DateTime.Parse(sms.ServiceCenterTimeStamp.ToString());
                    string state = "Received";
                    SaveMessage(messageBody, phoneNumber, messageDateTime, state);
                    break;
                case SMSType.StatusReport:
                    SmsStatusReport statusReport = new SmsStatusReport();
                    SmsStatusReport.Fetch(statusReport, ref messagePdu);
                    break;
            }          
        }
