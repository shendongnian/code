     public void AddDeviceToGroup(string user, string notificationKey, string registrationId)
        {
            DeviceGroupData deviceGroupData = new DeviceGroupData();
            deviceGroupData.Operation = "add";
            deviceGroupData.NotificationKeyName = user; 
            deviceGroupData.NotificationKey = notificationKey;
            deviceGroupData.RegistrationIds.Add(registrationId);
            DeviceGroupPost(deviceGroupData);
        }
     private string DeviceGroupPost(DeviceGroupData deviceGroupData)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(deviceEndPoint);
                byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(deviceGroupData));
                request.ProtocolVersion = HttpVersion.Version11;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "key=" + firebaseServerKey);
                request.Headers.Add("project_id", senderId);
                request.ContentLength = data.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    CustomLogger.LogError(null,"Failed to" + deviceGroupData.Operation + "Token to/from the deviceGroup for the userId" + deviceGroupData.NotificationKeyName);
                    return null;
                }
                stream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
                string info = readStream.ReadToEnd();
                var jsondata = JsonConvert.DeserializeObject<DeviceGroupData>(info);
                response.Close();
                readStream.Close();
                return jsondata.NotificationKey;
            }
            catch (Exception x)
            {
                CustomLogger.LogError(x, "Failed to" + deviceGroupData.Operation + "Token to/from the deviceGroup for the userId" + deviceGroupData.NotificationKeyName);
                return null;
            }
