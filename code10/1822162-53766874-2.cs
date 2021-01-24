    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            GetComponent<AudioSource>().Play();
            HPBAR.PlayHP -= Random.Range(5, 30);
            // If you can make HPBar.PlayHP a float, then you could do something like:
            // HPBAR.PlayHP -= Random.Range(5f,30f) * Time.deltaTime;
            // To take 5 - 30 damage per second.
            if (HPBAR.PlayHP < 0)// Insures player HP bar doesn't read less than zero in GUI TXT
            {
                HPBAR.PlayHP = 0;
    
            }
            // Debug.Log("Ouch! " + HPBAR.PlayHP + " Left");
            if (HPBAR.PlayHP <= 0 && HPBAR.lives > 0)
            {
                HPBAR.lives--;
                HPBAR.LPfloat--;
                p5.transform.position = spawner.transform.position;
                HPBAR.PlayHP = Random.Range(100, 150);
                // Debug.Log("You're Dead!!! Lives left: " + (HPBAR.lives + 1));
    
            }
            else if (HPBAR.PlayHP <= 0 && HPBAR.lives <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }
    
        } // of player tag check
    
    }// end of collision stay
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            // put "i quit touching the hurty thing" stuff here.
        }
    }
