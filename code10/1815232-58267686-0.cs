    using System.Reflection;
    using UnityEngine;
    namespace Assets.Test
    {
        public class TestBehaviour : MonoBehaviour
        {
            void Start()
            {
                Debug.Log(Assembly.GetAssembly(GetType()));
            }
        }
    }
