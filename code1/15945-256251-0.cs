    public class Control1 : IValidatableControl
    {
    ... Other methods
        public bool IsValidControl()
        {
            
            foreach(object c in this.Controls)
            {
                if(c.GetType() == "Control2")
                    return true;
            }
            return false;
        }
    
    }
