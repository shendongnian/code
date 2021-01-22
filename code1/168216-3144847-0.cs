    webClient.setWebConnection(new HttpWebConnection(webClient) {
      public WebResponse getResponse(WebRequestSettings settings) {
        System.out.println(settings.getUrl());
            return this.getResponse(settings);
      }
    });
