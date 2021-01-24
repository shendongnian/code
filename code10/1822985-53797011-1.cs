    using UnityEngine;
    public class RotatesCollection : MonoBehaviour
    {
    
        [SerializeField] AnimationCurve _speedAnimation = AnimationCurve.Linear( 0f , 0f , 4f , 100f );
        
        [SerializeField] Transform[] _objectsToRotate;
    
        float _timeEnabled;
    
        void OnEnable ()
        {
            //get time when enabled:
            _timeEnabled = Time.time;
    
            //change default wrap mode to loop:
            if( _speedAnimation.postWrapMode == WrapMode.Clamp )
            {
                _speedAnimation.postWrapMode = WrapMode.Loop;
            }
        }
    
        void Update ()
        {
            float deltaTime = Time.deltaTime;
            float timeSinceEnabled = Time.time - _timeEnabled;
            foreach( Transform rotor in _objectsToRotate )
            {
                //get speed from curve:
                float speed = _speedAnimation.Evaluate( timeSinceEnabled );
    
                //rotate:
                rotor.Rotate(
                    Vector3.up ,
                    deltaTime * speed ,
                    Space.World
                );
            }
        }
        
    }
