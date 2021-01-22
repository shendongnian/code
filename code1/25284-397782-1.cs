    public class Worker {
         public Worker Superior {get;set;}
         public readonly decimal WeightedSalary {
             get {
                  return (Superior.Salary * 2) + (this.Salary)
             }
         }
         public decimal Salary {get;set;}
    }
