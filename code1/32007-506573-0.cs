    public class TestView {
      private Test datasource;
      public TestView(Test source)
      { 
         this.datasource = source;
      }
      
       public string DisplayText {
         get {
           if (datasource.Text.Contains("<bold>")==false) {
               return "<bold>" + datasource.Text + "</bold>";
           }
           return datasource.Text;
         }
       }
    }
