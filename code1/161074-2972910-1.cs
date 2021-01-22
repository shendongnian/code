    namespace WinFormK
    {
        public class KForm(): System.Windows.Forms.Form
        {
            public void Do()
            {
                var service = new FWS.FooService();
                string filePath = "C:\\temp\FooData.xml";
                Bar[] fetched = service.GetFavoriteBars("yes!", null);
    
                //lets write this to local storage
                var frosties = new XmlSerializer(typeof(Bar));
                TextReader reader = new StreamReader(filePath);
              
                try
                {
                    var persisted = (T)frosties.Deserialize(reader);
                }
                catch(InvalidOperationException)
                {
                    //spock, do something
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
        }
    }
