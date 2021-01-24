    void FixedUpdate()
    {
     float moveHorizontal = Input.GetAxis("Horizontal");
     float moveVertical = Input.GetAxis("Vertical");
     Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
     GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }
    IEnumerator Wait1()
    { 
        if (Player.transform.position.y < -100.59)
        {
            TheText.text = "You Lost. Try Again!!";
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator Wait2()
    {
        if (Player.transform.position.y > 210)
        {
            TheText.text = "You Lost. Try Again!!";
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
