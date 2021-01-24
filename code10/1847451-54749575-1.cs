    public class ExpenseType : Entity
    {
     public ICollection<Expanse> Expanses {get; set;} = new HashSet<Expanse>()
    }
    public class Expense : Entity
    {
     public int? ExpanseTypeId {get; set;}
     public ExpanseType ExpanseType {get; set;}
    }
