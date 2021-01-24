    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Deny : MonoBehaviour {
        public string mess = "Are you sure?";
    Rect body;
    
    public vois Start(){
    body= new Rect(Screen.width / 2 - 150, Screen.height / 2 - 32, 300, 64)
    }
     
        private void OnGUI()
        {
            GUI.depth = -3;
            GUI.Box(body, mess);
            GUI.Button(new Rect(body.x+5,body.y+body.height-50, 110,46 ),"Yes"){
    //player clicked yes handle it
     //after your work : Destroy(this.gameObject);
    };
      GUI.Button(new Rect((body.x+body.width)-115,body.y+body.height-50, 110,46 
    ),"no"){
    //player clicked no handle it
    //after your work : Destroy(this.gameObject);
    };
         
        }
    }
