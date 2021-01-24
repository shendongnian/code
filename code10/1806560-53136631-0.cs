    public Camera curCam; 
    void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Player")
    {
        curCam.gameObject.SetActive(true);
    } // End of trigger check
    } // End of TriggerEnter
    void OnTriggerExit(Collider other)
    {
    if (other.tag == "Player")
    {
        curCam.gameObject.SetActive(false);
    }
    }
