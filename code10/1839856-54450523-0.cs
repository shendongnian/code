    public class BankAccount
    {
      ...
      public override bool Equals(object obj)
      {
        if (!(obj is BankAccount)) return false;
        var other = obj as BankAccount;
        return this.Owner.FirstName == other.Owner.FirstName &&
               this.Owner.LastName  == other.Owner.LastName  &&
               this.Balance         == other.Balance;
      }
    }
