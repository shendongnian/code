     if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
     {
         //logic for both A And W pressed
     }
    
     if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
     {
         //by checking if A is NOT pressed you will prevent this code from 
         //running if you press both A and W
         //Logic for just W pressed
     }
