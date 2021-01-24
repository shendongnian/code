    public class EnemyDetection
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy1")
            {
                HpSc.HP_Bar_Green.GameObject.SetActive(true);
                //or
                HpSc.HP_Bar_Green.enabled = true;
                // This is DetectEnemy trying to grab the image from the other script.
            }
        }
    }
