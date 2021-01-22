    string creds = "username:password";
    byte[] encData_byte = new byte[creds.Length];
    encData_byte = System.Text.Encoding.UTF8.GetBytes(creds);
    string encodedData = Convert.ToBase64String(encData_byte);
    objRequest.Headers.Add("Authorization", "Basic " + encodedData);
