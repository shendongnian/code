    public class Obstacle : MonoBehaviour 
    {
        public float damages;
        private void OnTriggerEnter(Collider other) 
        {  
            if(!other.gameObject.HasComponent<Player>())
                return;
            var player = other.gameObject.GetComponent<Player>();
            player.hp -= damages;
        }
    }
