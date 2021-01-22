    string credentials = String.Format("{0}:{1}", username, password);
    byte[] bytes = Encoding.ASCII.GetBytes(credentials);
    string base64 = Convert.ToBase64String(bytes);
    string authorization = String.Concat("Basic ", base64);
    request.Headers.Add("Authorization", authorization);
