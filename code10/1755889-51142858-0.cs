    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    
    
    public class tagChecker : MonoBehaviour {
        
        Camera m_MainCamera;
    
        void Start()
        {
            m_MainCamera = Camera.main;
        }
    
        void TagCheck()
        {
            if (GameObject.FindWithTag("1"))
            {
                m_MainCamera.transform.SetParent(GameObject.Find("Perspective1").transform); //GameObject.Find("A").transform.parent;
                m_MainCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
                m_MainCamera.transform.localRotation = Quaternion.identity;
                Destroy(GameObject.FindWithTag("1"));
            }
    
            else if (GameObject.FindWithTag("2"))
            {
                m_MainCamera.transform.SetParent(GameObject.Find("Perspective2").transform); //GameObject.Find("A").transform.parent;
                m_MainCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
                m_MainCamera.transform.localRotation = Quaternion.identity;
                Destroy(GameObject.FindWithTag("2"));
            }
    
            else if (GameObject.FindWithTag("3"))
            {
                m_MainCamera.transform.SetParent(GameObject.Find("Perspective3").transform); //GameObject.Find("A").transform.parent;
                m_MainCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
                m_MainCamera.transform.localRotation = Quaternion.identity;
                Destroy(GameObject.FindWithTag("3"));
            }
    
            else if (GameObject.FindWithTag("4"))
            {
                m_MainCamera.transform.SetParent(GameObject.Find("Perspective4").transform); //GameObject.Find("A").transform.parent;
                m_MainCamera.transform.localPosition = new Vector3(0f, 0f, 0f);
                m_MainCamera.transform.localRotation = Quaternion.identity;
                Destroy(GameObject.FindWithTag("4"));
            }
        }
    
        void Update()
        {
            TagCheck();
        }
    }
