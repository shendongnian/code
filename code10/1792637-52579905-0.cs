    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    
    public class ReleaseInputOpenKeyboard: MonoBehaviour
    {
        GraphicRaycaster m_Raycaster;
        EventSystem m_EventSystem;
    
        List<GameObject> inputFieldProcessedThisFrame = new List<GameObject>();
    
        void Start()
        {
            m_Raycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
            //Fetch the Event System from the Scene
            m_EventSystem = FindObjectOfType<EventSystem>();
        }
    
    
        void Update()
        {
    #if UNITY_STANDALONE || UNITY_EDITOR
            //DESKTOP COMPUTERS
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                SelectInputField();
            }
    #else
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                SelectInputField();
            }
    #endif
        }
    
        void SelectInputField()
        {
            //Set up the new Pointer Event
            PointerEventData m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;
    
            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();
    
            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);
    
            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                InputField ipf = result.gameObject.GetComponentInParent<InputField>();
                //Check if object hit is an InputField and make sure we have not processed this object this frame
                if (ipf && !inputFieldProcessedThisFrame.Contains(ipf.gameObject))
                {
                    Debug.Log("Hit " + ipf.gameObject.name);
    
                    //Mark this InputField as processed
                    inputFieldProcessedThisFrame.Add(ipf.gameObject);
    
                    //Enable interactable
                    ipf.interactable = true;
    
                    //Focus on the InputField
                    ActivateInputField(ipf, m_EventSystem);
    
                    //Add event to detect when the Input is deselected
                    ipf.onEndEdit.AddListener(delegate { OnInputEnd(ipf); });
                }
            }
    
            //Reset processed InputField
            if (inputFieldProcessedThisFrame.Count > 0)
                inputFieldProcessedThisFrame.Clear();
        }
    
        void ActivateInputField(InputField ipf, EventSystem evSys)
        {
            evSys.SetSelectedGameObject(ipf.gameObject, new BaseEventData(evSys));
            ipf.OnPointerClick(new PointerEventData(evSys));
        }
    
    
        //Detects when InputField is deselected then disable interactible
        void OnInputEnd(InputField ipf)
        {
            StartCoroutine(OnInputEndCOR(ipf));
        }
    
        IEnumerator OnInputEndCOR(InputField ipf)
        {
            //Disable interactable then remove event
            ipf.DeactivateInputField();
            ipf.onEndEdit.RemoveAllListeners();
    
            /*Wait until EventSystem is no longer in selecting mode
             This prevents the "Attempting to select while already selecting an object" error
             */
            while (EventSystem.current.alreadySelecting)
                yield return null;
    
            ipf.interactable = false;
        }
    }
