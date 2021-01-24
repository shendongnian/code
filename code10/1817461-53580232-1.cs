        IList<IWebElement> links = driver.FindElements(By.TagName("a")); 
        foreach (IWebElement link in links)
        {
          var url = link.getAttribute("href");
          IsLinkWorking(url);
        }
    
        bool IsLinkWorking(string url) {
           HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
    
           //You can set some parameters in the "request" object...
           request.AllowAutoRedirect = true;
    
           try {
              HttpWebResponse response = (HttpWebResponse) request.GetResponse();
			  if (response.StatusCode == HttpStatusCode.OK)
              {
			    Console.WriteLine("\r\nResponse Status Code is OK and 
                StatusDescription is: {0}", response.StatusDescription);
		     	// Releases the resources of the response.
			    response.Close(); 
                return true;
              }
              else
              {
                return false;
              }
           } catch { //TODO: Check for the right exception here
              return false;
           }
         }
