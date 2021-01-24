    #if UNITY_EDITOR
    using System.Collections;
    using System.Collections.Generic;
    using Script.Ro.Ext;
    using UnityEngine;
    
    public class TestVerticalMoveForward : MonoBehaviourExt
    {
        private GameObject from;
    
        private GameObject to;
    
        private GameObject target;
    //    private GameObject center;
    
        // Use this for initialization
        void Start()
        {
            from = GameObject.Find("From");
            to = GameObject.Find("To");
    //        center = GameObject.Find("Character/Center");
            target = from;
        }
    
        private float speed = 10;
    
        // Update is called once per frame
        void Update()
        {
            Watch("center.transform.position", transform.position);
            var offset = target.transform.position - transform.position;
    
            var forward = offset.normalized;
            var offset2 = speed * Time.deltaTime * forward;
            if (offset.magnitude <= offset2.magnitude)
            {
                transform.position += offset;
                if (target == to)
                {
                    target = from;
                }
                else
                {
                    target = to;
                }
            }
            else
            {
                transform.position += offset2;
            }
    
            if (offset != Vector3.zero)
            {
               var upAxis =  transform.rotation * Vector3.up;
                transform.rotation =
                    Quaternion.LookRotation(target.transform.position - transform.position, upAxis);
            }
        }
    }
    #endif
