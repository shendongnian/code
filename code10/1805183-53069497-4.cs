    public static string Where(HttpRequestMessage re) {
      string whereCLause = "";
    
      var headers = re.Headers;
      if (headers.Contains("whr")) {
        whereCLause = headers.GetValues("whr").First();
      } else {
        whereCLause = " ";
      }
      return whereCLause;
    }
