    private bool isPlayerClicked()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 100f); // only draws once. Re-clicking does nothing
            Debug.Log("mouse clicked"); 
            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player clicked " + hit.transform.name);
                return true;
            }
        }
        return false;
    }
