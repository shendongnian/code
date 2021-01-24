    public abstract class Ability<T> where T : IAbilityTarget
    {
        public abstract bool CanBeUsed( T[] targets );
        public abstract void Use( T[] targets );
    }    
    
    public class Fireball : Ability<IDamagable>
    {
        public override bool CanBeUsed( IDamagable[] targets )
        {
            return true ; // for the sake of the example
        }
    
        public override void Use( IDamagable[] targets )
        {
            for( int index = 0 ; index < targets.Length ; ++index )
                targets[index].Life -= 1 ;
        }
    }
