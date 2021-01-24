    float t = 0;
    Vector2 origpos;
    void Start() {
    }
    void Update () {
        if(Input.GetKeyDown(KeyCode.UpArrow))
              origpos = cube1.transform.position; //store position on keydown      
        if(Input.GetKey(KeyCode.UpArrow)){
            t += Time.deltaTime;
            cube1.transform.position = Vector3.Lerp(origpos, cube2.transform.position, t/2f); // where 2f is the amount of time you want the transition to take
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) 
            t = 0; // reset timer on key up
    }
