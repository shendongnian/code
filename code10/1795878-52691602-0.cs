    public Camera cameraPlayer;
    public Camera CameraCanhao;
    bool triggered = false;
    private void Start()
    {
        cameraPlayer.gameObject.SetActive(true);
        CameraCanhao.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && triggered)
        {
            if (cameraPlayer.gameObject.activeSelf)
            {
                cameraPlayer.gameObject.SetActive(false);
                CameraCanhao.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = false;
        }
    }
