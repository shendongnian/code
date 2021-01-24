    // Update is called once per frame
	void Update () {
        //Player input
        if (Input.GetMouseButtonDown(0))
        {
            bat.velocity = new Vector2(0, 4);
            //ADD BAT FLAP SOUND LATER!!!
        }
        scoreText.text = score.ToString();
        Debug.Log("SCORE: " + score);
    }
    //Point increment function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point" && batColliderIndex == 9)
        {
            score++;
            return;
        }
    }
