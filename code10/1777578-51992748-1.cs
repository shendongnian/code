    public class EnemyDetection
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy1")
            {
                HpSc healthBar = other.GetComponent<HpSc>();
                
                healthBar.GameObject.SetActive(true);
                //or
                healthBar.enabled = true;
            }
        }
    }
