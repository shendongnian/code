    public interface IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity);
    }
    
    public class AWrappedDisplay: IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity)
        {
            ADisplay disp = new ADisplay();
            return disp.ADisplay(entity);
        }
    
    }
    
    public class BWrappedDisplay : IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity)
        {
            BDisplay disp = new BDisplay();
            return disp.BDisplay(entity);
        }
    
    }
