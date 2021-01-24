        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
    
        public class MainCharacterMove : MonoBehaviour
    {    
        float MoveSpeed = 0f;
    
        // Use this for initialization
        void Start()
        {
            GameObject BaseCharacter = GameObject.Find("BaseCharacter");
            MainCharacterVarsScript mainCharacterVarsScript = mainCharacterVarsScript.GetComponent<MainCharacterVarsScript>();
            MoveSpeed = mainCharacterVarsScript.CharacterSpeed;
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    }
