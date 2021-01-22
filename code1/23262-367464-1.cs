    public abstract class AM
    {
        public int ID { get; set; }
        internal abstract void Save();
    }
    
    public class concreteIAM : AM
    {
        internal override void Save()
        {
            //Do some save stuff
        }
    }
