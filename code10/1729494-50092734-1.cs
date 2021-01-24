    class Program
    {
        static void Main(string[] args)
        {
            var myMedic = new SoldierMedic();
            myMedic.CurrentTask = new TaskHeal(myMedic); // Problem!
        }
    }
    public class SoldierBase
    {
        public int Status { get; set; }
    }
    public class SoldierBase<T> : SoldierBase where T : SoldierBase
    {
        public TaskBase CurrentTask { get; set; }
    }
    public class SoldierMedic : SoldierBase<SoldierMedic>
    {
        public int HealRate { get; set; } = 45;
    }
    public abstract class TaskBase
    {
    }
    public abstract class TaskBase<T> : TaskBase where T : SoldierBase<T>
    {
        protected T Soldier;
        public TaskBase(T unit)
        {
            Soldier = unit;
            Soldier.Status = 1;
        }
        public abstract void PerformTask();
    }
    public class TaskHeal : TaskBase<SoldierMedic>
    {
        public TaskHeal(SoldierMedic unit) : base(unit) { }
        public override void PerformTask()
        {
            Soldier.HealRate++;
        }
    }
