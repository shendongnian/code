    int state = 0;
    
    void Start(){
        audio = gameObject.GetComponent<AudioSource>();
    }
    
    void Update(){
        if (Input.GetKeyDown("space")){ // this was the offending line
            if (state == 0){
                audio.clip = SquaresLoop1;
                audio.Play();
                state = 1; // you don't need to re-declare state's type when setting it's value
            }
    
            if (state == 1){
                audio.clip = SquaresLoop2;
                audio.Play();
                state = 0;
            }
        }               
    }
