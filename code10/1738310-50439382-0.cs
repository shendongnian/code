     float lastpos;    
     void Start()
            {
            lastpos = transform.position.x;
            InvokeRepeating("checkPos", 0.01, 2.0);
            }
            
         void checkPos(){
            if(transform.position.x < lastpos){
               //decreasing 
            }
            else{
              //increasing
            }
            lastpos = transform.position.x;
            }
