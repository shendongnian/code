                    public class Jointsiguess : MonoBehaviour
                    {      
    HingeJoint hinge;
    PlayerManager playerManager;
    JointSpring hingeSpring;
                    void Awake()
                    {
                       hinge = GetComponent<HingeJoint>();
                      hingeSpring = hinge.spring;
                       playerManager = FindObjectOfType<PlayerManager>();
                    }
    }
