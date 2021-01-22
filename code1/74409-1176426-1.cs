    public interface IMyComparable<T>
    {
       bool MyComparableMethod(T account);
    }
        
    public interface IBankAccount : IMyBusinessObjectBase,  IMyComparable<T>
    {
    ...
       public bool MyComparableMethod(IBankAccount account)
       {
           return this.AccountNumber == account.AccountNumber && 
                   this.Bank.Name == account.Bank.Name &&
                   this.Id != account.Id;
       }
    }
    public ValidationError Validate<T>(T entityProperty) where T : IMyComparable<T>
    {
    ...
         if (!businessObjectList.Any(x => entityProperty.MyComparableMethod(x))
             return new ValidationError(_DuplicateMessage);
    ...
