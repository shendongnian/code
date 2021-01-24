    void Update () {
       transform.Translate(Vector3.forward*speed*Time.deltaTime);
       m_Anim.SetFloat("H_Speed", speed);
       if (Input.GetKeyDown(KeyCode.UpArrow)){ 
           speed++;}
       if (Input.GetKeyDown(KeyCode.DownArrow)){ 
           speed--;}
    }
