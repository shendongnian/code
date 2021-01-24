    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;
    
    public class ExampleClass : MonoBehaviour {
    
        private ParticleSystem ps;
        private List<Vector4> customData = new List<Vector4>();
        private int uniqueID;
    
        void Start() {
    
            ps = GetComponent<ParticleSystem>();
        }
    
        void Update() {
    
            ps.GetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
    
            for (int i = 0; i < customData.Count; i++)
            {
                // set custom data to the next ID, if it is in the default 0 state
                if (customData[i].x == 0.0f)
                {
                    customData[i] = new Vector4(++uniqueID, 0, 0, 0);
                }
            }
    
            ps.SetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
        }
    }
