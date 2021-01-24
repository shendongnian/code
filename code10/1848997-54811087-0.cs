    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class GetPasswords : MonoBehaviour
    {
    
        string URL = "http://localhost:8888/sqlconnect/usergetpasswords.php";
    
        public void RetrievePasswords()
        {
            StartCoroutine(DisplayPasswords());
        }
    
        IEnumerator DisplayPasswords()
        {
            WWWForm form = new WWWForm();
            form.AddField("email", DBManager.email);
            WWW www = new WWW(URL, form);
            yield return www;
            Debug.Log("User Info = " + www.text);
        }
    
    }
