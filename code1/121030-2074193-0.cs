    public interface IBelch
    {
        void Belch();
    }
    public class Coke : IBelch
    {
        public void Belch()
        {
        }
    }
    public class GatorAde : IBelch
    {
        public void Belch()
        {
        }
    }
    public class SoftDrink<T>
        where T : IBelch
    {
        public void DrinkFast(T drink)
        {
            drink.Belch();
        }
    }
