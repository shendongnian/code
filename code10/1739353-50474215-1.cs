    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class KeyboardEventSystem : MonoBehaviour
    {
        Array allKeyCodes;
    
        private static List<Transform> allTransforms = new List<Transform>();
        private static List<GameObject> rootGameObjects = new List<GameObject>();
    
        void Awake()
        {
            allKeyCodes = System.Enum.GetValues(typeof(KeyCode));
        }
    
        void Update()
        {
            //Loop over all the keycodes
            foreach (KeyCode tempKey in allKeyCodes)
            {
                //Send event to key down
                if (Input.GetKeyDown(tempKey))
                    senEvent(tempKey, KeybrdEventType.keyDown);
    
                //Send event to key up
                if (Input.GetKeyUp(tempKey))
                    senEvent(tempKey, KeybrdEventType.KeyUp);
    
                //Send event to while key is held down
                if (Input.GetKey(tempKey))
                    senEvent(tempKey, KeybrdEventType.down);
    
            }
        }
    
    
        void senEvent(KeyCode keycode, KeybrdEventType evType)
        {
            GetAllRootObject();
            GetAllComponents();
    
            //Loop over all the interfaces and callthe appropriate function
            for (int i = 0; i < allTransforms.Count; i++)
            {
                GameObject obj = allTransforms[i].gameObject;
    
                //Invoke the appropriate interface function if not null
                IKeyboardEvent itfc = obj.GetComponent<IKeyboardEvent>();
                if (itfc != null)
                {
                    if (evType == KeybrdEventType.keyDown)
                        itfc.OnKeyDown(keycode);
                    if (evType == KeybrdEventType.KeyUp)
                        itfc.OnKeyUP(keycode);
                    if (evType == KeybrdEventType.down)
                        itfc.OnKey(keycode);
                }
            }
        }
    
        private static void GetAllRootObject()
        {
            rootGameObjects.Clear();
    
            Scene activeScene = SceneManager.GetActiveScene();
            activeScene.GetRootGameObjects(rootGameObjects);
        }
    
    
        private static void GetAllComponents()
        {
            allTransforms.Clear();
    
            for (int i = 0; i < rootGameObjects.Count; ++i)
            {
                GameObject obj = rootGameObjects[i];
    
                //Get all child Transforms attached to this GameObject
                obj.GetComponentsInChildren<Transform>(true, allTransforms);
            }
        }
    
    }
    
    public enum KeybrdEventType
    {
        keyDown,
        KeyUp,
        down
    }
    
    public interface IKeyboardEvent
    {
        void OnKeyDown(KeyCode keycode);
        void OnKeyUP(KeyCode keycode);
        void OnKey(KeyCode keycode);
    }
