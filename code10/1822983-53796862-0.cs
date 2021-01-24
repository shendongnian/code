    using UnityEngine;
    public class RotatesCollection : MonoBehaviour
    {
        
        [SerializeField] Transform[] _objectsToRotateManual;
        [SerializeField] Transform[] _objectsToRotateAutomatic;
        int _value = 0;
        int _valueDelta = 1;
    
        void Update ()
        {
            float deltaTime = Time.deltaTime;
            foreach( Transform rotor in _objectsToRotateAutomatic )
            {
                //step:
                _value += _valueDelta;
                
                //reverse step direction when min/max value is met:
                if( _value==0 || _value==100 ) { _valueDelta *= -1; }
    
                //rotate:
                rotor.Rotate(
                    Vector3.up ,
                    deltaTime * _value ,
                    Space.World
                );
            }
        }
        
    }
