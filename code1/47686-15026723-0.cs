    #define WRITE_FORMATTED_XML
    
    using System.Xml;
    
    namespace ClipFlair.Windows
    {
    
      public partial class BaseWindow : FloatingWindow
      {
    
        //...
    
        #if WRITE_FORMATTED_XML
        private static XmlWriterSettings XML_WRITER_SETTINGS = new XmlWriterSettings() { Indent=true, IndentChars="  "};
        #endif
        //...
    
        public virtual void SaveOptions(ZipFile zip, string zipFolder = "") //THIS IS THE CORE SAVING LOGIC
        {
          if (SavingOptions != null) SavingOptions(this, null); //notify any listeners
    
          View.Busy = true;
          try
          {
            ZipEntry optionsXML = zip.AddEntry(zipFolder + "/" + View.GetType().FullName + ".options.xml",
              new WriteDelegate((entryName, stream) =>
              {
                DataContractSerializer serializer = new DataContractSerializer(View.GetType()); //assuming current View isn't null
                #if WRITE_FORMATTED_XML
                using (XmlWriter writer = XmlWriter.Create(stream, XML_WRITER_SETTINGS))
                  serializer.WriteObject(writer, View);
                #else
                serializer.WriteObject(stream, View);
                #endif
              }));
          }
          catch (Exception e)
          {
            MessageBox.Show("ClipFlair options save failed: " + e.Message); //TODO: find the parent window
          }
          finally
          {
            View.Busy = false; //in any case (error or not) clear the Busy flag
          }
          if (SavedOptions != null) SavedOptions(this, null); //notify any listeners
        }
        //...
      }
    }
