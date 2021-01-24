    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class NewBehaviourScript : MonoBehaviour
    {
        public float Speed = 300.0f;
    
        void Update()
        {
            var w = Screen.width / 4.0f;
            var h = Screen.height;
            var r1 = new Rect(w * 0, 0.0f, w, h);
            var r2 = new Rect(w * 1, 0.0f, w, h);
            var r3 = new Rect(w * 2, 0.0f, w, h);
            var r4 = new Rect(w * 3, 0.0f, w, h);
    
            var t1 = Input.GetTouch(0);
            var tc = Input.touchCount;
    
            if (tc == 1 && t1.phase == TouchPhase.Began)
            {
                var pos = t1.position;
                var dir = Vector3.zero;
    
                if (r1.Contains(t1.position))
                    dir = Vector3.back;
    
                if (r2.Contains(pos))
                    dir = Vector3.forward;
    
                transform.Rotate(dir * Speed);
            }
        }
    }
