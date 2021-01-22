    try
    {
      Uri uri = new Uri(path);
      HttpWebRequest request = HttpWebRequest.Create(uri);
      request.Timeout = 3000;
      HttpWebResponse response;
      response = request.GetResponse();
      if (response.StatusCode.Equals(200))
      {
         //great - something is there
      }
    }
    catch(Exception loi) 
    { 
      MessageBox.Show(loi.Message); 
    }
