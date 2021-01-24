    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Playables;
    
    public class SpaceshipCutscene : MonoBehaviour
    {
        public Transform player;
        public Transform npc;
        public Camera FPSCamera;
        public Camera mainCamera;
        public Animator anim;
        public float rotationSpeed = 3f;
    
        private bool moveNpc = false;
    
        // Use this for initialization
        void Start()
        {
    
        }
    
        private void Update()
        {
            if (moveNpc)
            {
              Vector3 dir = player.position - npc.position;
            dir.y = 0; // keep the direction strictly horizontal
            Quaternion rot = Quaternion.LookRotation(dir);
            // slerp to the desired rotation over time
            npc.rotation = Quaternion.Slerp(npc.rotation, rot, rotationSpeed * Time.deltaTime);
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Horizontal_Doors_Kit")
            {
                FPSCamera.enabled = false;
                mainCamera.enabled = true;
                moveNpc = true;
                anim.SetTrigger("SoldierAimingTrigger");
            }
        }
    }
