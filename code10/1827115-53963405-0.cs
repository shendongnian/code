    int width = 0;
    Int32.TryParse(value, out width);
    HttpCookie deviceType = new HttpCookie("device-type");
    if (width < 768)
    {
        deviceType.Value = "hallo";
    }
    else
    {
        deviceType.Value = "hallo";
    }
    Response.Cookies.Add(deviceType);
