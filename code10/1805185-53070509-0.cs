    void OnMouseDown()
    {
       
       RaycastHit hit; 
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
       if ( Physics.Raycast (ray,out hit,100.0f)) 
       {
          Civilian c = hit.collider.gameObject.GetComponent<Civilian>();
          c.Sleep();
       }
    }
