    if (Request.Properties.TryGetValue("MS_HttpContext", out object context))
     {
     if (context is HttpContextWrapper wrapper)
      {
      var v = wrapper.Request?.ServerVariables;
      if (v != null)
       {
       var headers = response.Headers;
       const string CRYPT_PROTOCOL = nameof(CRYPT_PROTOCOL);
       try
        {
        headers.Add($"SV_{CRYPT_PROTOCOL}", $"[{v[CRYPT_PROTOCOL].Replace("\r", "0x0D").Replace("\n", "0x0A")}]");
        }
        catch (Exception ex)
        {
           headers.Add($"SV_{CRYPT_PROTOCOL}", ex.Message);
        }
        foreach (string key in v.AllKeys)
          {
          headers.Add($"SV_{key}", v[key].Replace("\r", "0x0D").Replace("\n", "0x0A"));
          }
         headers.Add($"SV_DONE", "All Server Variables Replaced");
         }
      }
