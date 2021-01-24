    public class DemoInheritanceChild : DemoInheritance
    {
        public override void OnTakeDamage(float damage)
        {
            base.OnTakeDamage(damage);
            Debug.Log("Child Damage: " + damage);
        }
    }
