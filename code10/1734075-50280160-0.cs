     namespace ConsoleApplication1
        {
            public enum State
            {
                IDLE = 0,
                WALK = 1,
                JUMP = 2,
                FALL = 3,
                CLIMB = 4,
                LOOKING_DOWN = 5,
                NPC = 6,
                IMPATIENT = 7,
                LOOKING_UP = 8,
                STUCK = 9,
            }
        
            public abstract class Character : MonoBehaviour
            {
                protected abstract State CurrentState
                {
                    get;
                    set;
                }
            }
        
            
            public class MonoBehaviour
            {
            }
        
            public class Player : Character
            {      
        
                protected override State CurrentState
                {
                    get
                    {
                        return (State)_anim.GetInteger("State");
                    }
                    set
                    {
                        _anim.SetInteger("State", Convert.ToInt32(value));
                    }
                }
        
                
        
                void FixedUpdate()
                {
                    if (CurrentState == State.CLIMB)
                    {
        
                    }
                }
        
            }
             
        }
