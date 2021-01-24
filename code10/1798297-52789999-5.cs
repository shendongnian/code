    void Update() 
     {
         if (buttonPress == a) 
         {
             // Make sure the Coroutine only is running once
             StopCoroutine(MoveCamera);
             positionToMoveTo = positions[currentPosition--];
             StartCoroutine (MoveCamera);
         } 
         if (buttonpress == b) 
         {
             // Make sure the Coroutine only is running once
             StopCoroutine (MoveCamera);
             positionToMoveTo = positions[currentPosition++];
             StartCoroutine (MoveCamera);
         }
     }
