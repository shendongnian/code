    public class Ship
    {    
        public virtual bool Validate()    
        {        
            //validate properties only found on a ship
            return true;
        }
    }
    public class Lifeboat : Ship
    {   
        public override bool Validate()   
        {       
            base.Validate();       
            // lifeboat specific code
            return true;
        }
    }
