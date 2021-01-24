    RaycastHit hit;
     void Update()
     {
        if (Input.GetMouseButtonDown (0))
        {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if(Physics.Raycast(ray, out hit,2f))
           {
              GameObject ourObject = hit.collider.gameObject;
              string prefix = "spr_boards ";
              string txtNum = ourObject.transform.name.Remove(0, prefix.Length);
              int number = Int32.Parse(txtNum);
              Debug.Log ("this is object " + number);
           }
        }
     }
