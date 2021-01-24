    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class CameraController : MonoBehaviour
    {
    
        public Transform target;
        Vector3 targetPos;
    
        void Update()
        {
            targetPos = target.position;
            transform.position = new Vector3(targetPos.x + 10f, targetPos.y + 8.571067812f, targetPos.z - 10f);
            // transform.LookAt(target.transform);
        }
    }
