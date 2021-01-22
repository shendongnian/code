        /// <summary>
        /// Send an electronic message using the Collaboration Data Objects (CDO).
        /// </summary>
        /// <remarks>http://support.microsoft.com/kb/310212</remarks>
        private void SendTestCDOMessage()
        {
            try
            {
                string yourEmail = "YourUserName@gmail.com";
                CDO.Message message = new CDO.Message();
                CDO.IConfiguration configuration = message.Configuration;
                ADODB.Fields fields = configuration.Fields;
                Console.WriteLine(String.Format("Configuring CDO settings..."));
                // Set configuration.
                // sendusing:               cdoSendUsingPort, value 2, for sending the message using the network.
                // smtpauthenticate:     Specifies the mechanism used when authenticating to an SMTP service over the network.
                //                                  Possible values are:
                //                                  - cdoAnonymous, value 0. Do not authenticate.
                //                                  - cdoBasic, value 1. Use basic clear-text authentication. (Hint: This requires the use of "sendusername" and "sendpassword" fields)
                //                                  - cdoNTLM, value 2. The current process security context is used to authenticate with the service.
                ADODB.Field field = fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"];
                field.Value = "smtp.gmail.com";
                field = fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"];
                field.Value = 465;
                field = fields["http://schemas.microsoft.com/cdo/configuration/sendusing"];
                field.Value = CDO.CdoSendUsing.cdoSendUsingPort;
                field = fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"];
                field.Value = CDO.CdoProtocolsAuthentication.cdoBasic;
                field = fields["http://schemas.microsoft.com/cdo/configuration/sendusername"];
                field.Value = yourEmail;
                field = fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"];
                field.Value = "YourPassword";
                field = fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"];
                field.Value = "true";
                fields.Update();
                Console.WriteLine(String.Format("Building CDO Message..."));
                message.From = yourEmail;
                message.To = yourEmail;
                message.Subject = "Test message.";
                message.TextBody = "This is a test message. Please disregard.";
                Console.WriteLine(String.Format("Attempting to connect to remote server..."));
                // Send message.
                message.Send();
                Console.WriteLine("Message sent.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
