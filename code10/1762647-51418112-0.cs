    public override void Use( IAbilityTarget[] targets )
    {
        for( int index = 0 ; index < targets.Length ; ++index ) {
            if (targets[index] is IDamagable) {
                ((IDamagable)targets[index]).Life -= 1 ;
            }
        }
    }
