    public interface IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity);
    }
    
    public class AWrappedDisplay: IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity)
        {
            ADisplay disp = new ADisplay();
            return disp.ADisplayFunc(entity);
        }
    
    }
    
    public class BWrappedDisplay : IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity)
        {
            BDisplay disp = new BDisplay();
            return disp.BDisplayFunc(entity);
        }
    
    }
    public static IDisplay Factory(Type t)
            {
               IDisplay disp = null;
               if (t == typeof(ADisplayEntity))
                   disp = new AWrappedDisplay();
    
               if (t == typeof(BDisplayEntity))
                   disp = new BWrappedDisplay();
    
                return disp;
            }
