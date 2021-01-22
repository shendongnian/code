    public class MyBusinessLogic {
       public MyBusinessLogic(String filePath) {
          this.FilePath = filePath;
       }
       public String FilePath { get; private set; }
       public void Process() {
          // whatever you do here
       }
    }
