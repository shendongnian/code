    [WebMethod]
    public int Insert(string userDate, string DeviceID) {
        DateTime date;
        int device;
        try {
            date = XmlConvert.ToDateTime(userDate, XmlDateTimeSerializationMode.Local);
            device = XmlConvert.ToInt32(DeviceID);
        } catch (Exception) {
            // Throw an error
            return -1;
        }
        UsersDatesBLL BLL = new UsersDatesBLL();
        return BLL.Insert(device, date);
    }
