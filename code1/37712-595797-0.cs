    public class PersonMapper {
      protected virtual void AggregateAttributes(List<string> list) {
        list.AddRange(attributes);
      }
      public List<string> GetAttributes() {
        List<string> list = new List<string>();
        AggregateAttributes(list);
        return list;
      }
    }
    
    public class UserMapper {
      protected override void AggergateAttributes(List<string> list) {
        base.AggregateAttributes(list);
        list.AddRange(attributes);
      }
    }
    
    public class EmployeeMapper {
      protected override void AggergateAttributes(List<string> list) {
        base.AggregateAttributes(list);
        list.AddRange(attributes);
      }
    }
