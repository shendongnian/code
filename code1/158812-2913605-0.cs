    NameValueCollection values = new NameValueCollection();
    values.Add("action","hotelPackageWizard@searchHotelOnly");
    values.Add("packageType","HOTEL_ONLY");
    // etc..
    WebClient webclient = new WebClient();
    webclient.Headers.Add("Content-Type","application/x-www-form-urlencoded");
    byte[] responseArray = webclient.UploadValues("http://www.expedia.com/Hotels?rfrr=-905&","POST", values);
    string response = System.Text.Encoding.ASCII.GetString(responseArray);
