    @functions {
      private string url = string.Empty;
      protected override void OnInit() {
        string url = UriHelper.GetAbsoluteUri();
        string[] parameters = url .Replace(UriHelper.GetBaseUri(), "").Replace("#", "").Split('&');
        string token = string.Empty;
 
        foreach (string prm in parameters) {
          if (prm.IndexOf("token=") >= 0) {
            token = prm.Replace("token=", "");
          }
        }
        UriHelper.OnLocationChanged += OnLocationChanged;
      }
      private void OnLocationChanged(object sender, string newUriAbsolute) {
        url = newUriAbsolute;
      }
      public void Dispose() {
        UriHelper.OnLocationChanged -= OnLocationChanged;
      }
    }
