    public class DemoInheritance : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float damage = 10;
                OnTakeDamage(damage);
            }
        }
        private void OnTakeDamage(float damage)
        {
            Debug.Log("Base Damage: " + damage);
            damage -= 5;
            Debug.Log("New Damage: " + damage);
            PostDamageResolved(damage);
        }
        protected virtual void PostDamageResolved(float postResolutionDamage);
    }
    public class DemoInheritanceChild : DemoInheritance
    {
        protected override void PostDamageResolved(float postResolutionDamage)
        {
            Debug.Log("Child Damage: " + postResolutionDamage);
        }
    }
