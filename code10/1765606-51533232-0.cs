    public void TestClickEvent()
    {
        Vector2 point = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log("I hit something :" + hit.collider.gameObject.name);
        }        
    }
