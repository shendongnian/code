    public interface ISaveable {
       void SaveFields();
    }
    public abstract class Evaluation : ISaveable {
      public int Id
      public string Comment
      
      public virtual void SaveFields()
      {
         //Save ID and Comments
      }
    }
    public class EvaluationType_1 : Evaluation {
        public string field1
      public override void SaveFields()
      {
         //Save field1
         base.SaveFields();
      }
    }
    public class EvaluationType_2 : Evaluation {
       public string field2
      public override void SaveFields()
      {
         //Save field2
         base.SaveFields();
      }
    }
