    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using K3DBHandler;
    
    public class Splash : MonoBehaviour {
        private int jmlUser = 0;
        private DataService ds = null;
    
        void Start()
        {
           ds = new DataService("dbK3.sqlite");
           var user = ds.CekUser();
           Hitung(user);
           if (jmlUser == 0) StartCoroutine(ToLogin());
           else StartCoroutine(ToHome());
        }
    
        IEnumerator ToHome()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Home");
        }
    
        IEnumerator ToLogin()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Login");
        }
        private void Hitung(IEnumerable<User> UserCount)
        {
            int c = 0;
            foreach (var a in UserCount) c++;
            jmlUser = c;
        }
    }
