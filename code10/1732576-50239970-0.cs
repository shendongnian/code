    public bool Initialise(string cameraAddress, string userName, string password)
        {
            bool result = false;
            try
            {
                var messageElement = new TextMessageEncodingBindingElement()
                {
                    MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.WSAddressing10)
                };
                HttpTransportBindingElement httpBinding = new HttpTransportBindingElement()
                {
                    AuthenticationScheme = AuthenticationSchemes.Digest
                };
                CustomBinding bind = new CustomBinding(messageElement, httpBinding);
                System.Net.ServicePointManager.Expect100Continue = false;
                DeviceClient deviceClient = new DeviceClient(bind, new EndpointAddress($"http://{cameraAddress}/onvif/device_service"));
                var temps = deviceClient.GetSystemDateAndTime();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return result;
        }
