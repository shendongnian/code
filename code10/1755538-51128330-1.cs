    public class helloTrigger : MonoBehaviour
    {
        public Animator anim;
        public CharacterController player;
        public Transform Player;
        Coroutine smoothMove = null;
    
        // Use this for initialization
        void Start()
        {
            player = GameObject.FindObjectOfType<CharacterController>();
            anim = GetComponent<Animator>();
        }
    
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                anim.Play("Hello");
                LookSmoothly();
            }
    
        }
    
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                anim.Play("Idle");
            }
        }
    
        void LookSmoothly()
        {
            float time = 1f;
    
            Vector3 lookAt = Player.position;
            lookAt.y = transform.position.y;
    
            //Start new look-at coroutine
            if (smoothMove == null)
                smoothMove = StartCoroutine(LookAtSmoothly(transform, lookAt, time));
            else
            {
                //Stop old one then start new one
                StopCoroutine(smoothMove);
                smoothMove = StartCoroutine(LookAtSmoothly(transform, lookAt, time));
            }
        }
    
        IEnumerator LookAtSmoothly(Transform objectToMove, Vector3 worldPosition, float duration)
        {
            Quaternion currentRot = objectToMove.rotation;
            Quaternion newRot = Quaternion.LookRotation(worldPosition -
                objectToMove.position, objectToMove.TransformDirection(Vector3.up));
    
            float counter = 0;
            while (counter < duration)
            {
                counter += Time.deltaTime;
                objectToMove.rotation =
                    Quaternion.Lerp(currentRot, newRot, counter / duration);
                yield return null;
            }
        }
    }
