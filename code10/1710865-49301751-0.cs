    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK;
    public class System_2_Script_Slider_X : MonoBehaviour
    {
        private float _timeWhenGrabbed;
        void Start()
        {
            if (GetComponent<VRTK_InteractableObject>() == null)
            {
                Debug.LogError("Team3_Interactable_Object_Extension is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");
                return;
            }
            GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
            GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUngrabbed);
        }
        private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            //Some Code
            _timeWhenGrabbed = Time.time;
        }
        private void ObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            //Some Code
            var grabDuration = Time.time - _timeWhenGrabbed;
            File.AppendAllText("PATH/Timer.txt", grabDuration.ToString());
        }
    }
