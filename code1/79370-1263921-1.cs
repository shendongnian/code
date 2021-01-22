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
