    public interface Icontainer
    {
        string name();
    }
    public abstract class fuzzyContainer : Icontainer
    {
        public virtual string name()
        {
            return "Fuzzy Container";
        }
    }
    public class specialContainer : fuzzyContainer
    {
        public override string name()
        {
            return base.name() + " Special Container";
        }
    }
