    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Rotater : MonoBehaviour {
    public Transform player;
    public float touchSensitivityScale;
    void Update()
    {
        if (Input.touchCount == 1)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);
            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                player.transform.Rotate(0f, 0f, touch0.deltaPosition.x * touchSensitivityScale);
            }
        }
    }
    }
