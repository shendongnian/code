     public abstract class Worker
    {
        public abstract float Salary { get; } 
    }
    public class Driver : Worker
    {
           public class Driver : Worker
          {
        float _salary = 0;
        public Driver(float Salary)
        {
            _salary = Salary;
        } 
        public override float Salary { get { return _salary; } } 
        //for testing i just hard coded '3000' value
       }
    }
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker; 
        protected Worker worker { get; private set; }
    }
    public class AmountBonus : Bonus
    {
        public AmountBonus(Worker worker) : base(worker: worker) { }
        public override float Salary
        {
            get
            {
                return worker.Salary +200;
            }
        }
    }
      static void Main(string[] args)
        {
            var driver = new Driver(3200);
            Console.WriteLine(driver.Salary);
            var driverSalWithBonus = new AmountBonus(driver);
            Console.WriteLine(driverSalWithBonus.Salary);
            Console.ReadLine();
        }
