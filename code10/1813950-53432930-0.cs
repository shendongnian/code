    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.Escape))
      {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.setActive(true);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.setActive(false);
         }
      }
    }
