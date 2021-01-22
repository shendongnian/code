    public class FireBallCommand : Command
    {
        public override void Perform(Entity source, Entity target)
        {
            // a fireball hurts the target and blows it back
            var damageTarget = target as IDamageable;
            if (damageTarget != null)
            {
                damageTarget.TakeDamage(234);
            }
            
            var moveTarget = target as IMoveable;
            if (moveTarget != null)
            {
                moveTarget.Move(1, 1);
            }
        }
    }
