      public class Tests
      {
             public static string CombineUrl (string baseUrl, string path)
             {
               var uriBuilder = new UriBuilder (baseUrl);
               uriBuilder.Path = Path.Combine (uriBuilder.Path, path);
               return uriBuilder.ToString();
             }
         
             [TestCase("http://MyUrl.com/", "/Images/Image.jpg", "http://myurl.com:80/Images/Image.jpg")]
             [TestCase("http://MyUrl.com/basePath", "/Images/Image.jpg", "http://myurl.com:80/Images/Image.jpg")]
             [TestCase("http://MyUrl.com/basePath", "Images/Image.jpg", "http://myurl.com:80/basePath/Images/Image.jpg")]
             [TestCase("http://MyUrl.com/basePath/", "Images/Image.jpg", "http://myurl.com:80/basePath/Images/Image.jpg")]
             public void Test1 (string baseUrl, string path, string expected)
             {
               var result = CombineUrl (baseUrl, path);
               
               Assert.That (result, Is.EqualTo (expected));
             }
      }
