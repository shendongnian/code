    class Program
    {
        static void Main(string[] args)
        {
            var myMedic = new SoldierMedic();
            myMedic.setTask(new TaskHeal(myMedic)); // Problem!
        }
    }
    public class SoldierBase
    {
        public int status;
    }
    public class SoldierBase<T> : SoldierBase where T : SoldierBase
    {
        private TaskBase currentTask;
        public void setTask(TaskBase newTask)
        {
            this.currentTask = newTask;
        }
    }
    public class SoldierMedic : SoldierBase<SoldierMedic>
    {
        public int healRate = 45;
    }
    public abstract class TaskBase
    {
    }
    public abstract class TaskBase<T> : TaskBase where T : SoldierBase<T>
    {
        protected T soldier;
        public TaskBase(T unit)
        {
            this.soldier = unit;
            this.soldier.status = 1;
        }
        public abstract void preformTask();
    }
    public class TaskHeal : TaskBase<SoldierMedic>
    {
        public TaskHeal(SoldierMedic unit) : base(unit) { }
        public override void preformTask()
        {
            this.soldier.healRate++;
        }
    }
