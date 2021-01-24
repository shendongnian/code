    public class GameManager : MonoBehaviour
    {
        public GameObject[] _dice;
    
        public Vector3 _rollStartPosition;
        public float _rollForce;
        public float _rollTorque;
        bool doneRolling = true;
    
        void Update()
        {
            if (doneRolling && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(RollDice());
            }
        }
    
        IEnumerator RollDice()
        {
            doneRolling = false;
    
            foreach (var die in _dice)
            {
                // Roll() adds force and torque from a given starting position
                die.GetComponent<Die>()
                   .Roll(_rollStartPosition, Random.onUnitSphere * _rollForce, Random.onUnitSphere * _rollTorque);
            }
    
            //Wait until all dice tops moving
            yield return CheckIfDiceAreMoving();
    
    
            // Calculate score and do something with it...
    
    
            //Set doneRolling to true so that we call this funtion again
            doneRolling = true;
        }
    
        IEnumerator CheckIfDiceAreMoving()
        {
            foreach (var die in _dice)
            {
                var dieRigidbody = die.GetComponent<Rigidbody>();
                //Wait until all dice stops moving
                while (!dieRigidbody.IsSleeping())
                {
                    yield return null;
                }
            }
        }
    }
