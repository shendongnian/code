        public abstract class Unit
        {
    
          public virtual string GetDescription()
          {
    	     return "Unit";
          }
    
          public virtual double Cost()
          {
             return 100;
          }
       }
    
       public abstract class EffectDecorator : Unit
       {
          public EffectDecorator()
          {
          }
       }
    
      
    
       public class UnitWithPowerUp : EffectDecorator
       {
          Unit unit;
            		
          public UnitWithPowerUp(Unit unit)
          {
             this.unit = unit;
          }
            
          public override string GetDescription()
          {
             return unit.GetDescription() + " + Power Up";
          }
            
          public override double Health()
          {
             return unit.Health() * 1.10;
          }
       }
