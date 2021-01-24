    Script A:
    // variables
         public ScriptC c;
    
    // methods
    void SpawnB(){
        // spawn B
        B.setC(c); // B's variable for script C is passed in from A
    }
    Script B:
    // variables
         ScriptC c;
    // methods
    void setC(ScriptC v){
        c = v;
    }
 
