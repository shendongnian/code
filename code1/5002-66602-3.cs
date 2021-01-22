    public interface ICommand {
          String getName();
    }
    
    public class RealCommand implements ICommand {
         public String getName() {
               return "name";
         }
    }
