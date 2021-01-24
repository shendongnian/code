    public abstract class Worker
    {
        public float UsdPerHour { get; set; }
        public int HoursPerDay { get; set; }
        public int DaysOfWork { get; set; }
        public abstract float CountSalary();
    }
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker;
        public override float CountSalary() => worker.CountSalary();
        protected Worker worker { get; private set; }
    }
    public class AmountBonus : Bonus
    {
        public AmountBonus(Worker worker) : base(worker: worker){ }
        public override float CountSalary()
        {
            throw new NotImplementedException();
        }
    }
