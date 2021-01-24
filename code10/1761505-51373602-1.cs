    using UnityEngine;
    using System.Collections.Generic;
    
    public class Test : MonoBehaviour
    {
        float timer = 0.0f;
        public TestSO so;
    
        public void Update ( )
        {
            timer += Time.deltaTime;
    
            if ( timer > 1.0f )
            {
                timer -= 1.0f;
                so.Vectors.Add ( new Vector3 ( UnityEngine.Random.Range ( 0, 10 ), UnityEngine.Random.Range ( 0, 10 ), UnityEngine.Random.Range ( 0, 10 ) ) );
            }
        }
    }
    
    [CreateAssetMenu ( fileName = "TestSO", menuName = "Create TestSO", order = 0 )]
    public class TestSO : ScriptableObject
    {
        public List<Vector3> Vectors;
    }
