    private void OnCollisionEnter2D(Collision2D collision)
    {
      IsDead = true;
      anim.SetTrigger("Die");
      transform.GetChild(0).GetComponent<Animator>().SetTrigger("StopBubble");
      Debug.Log("rigger");             
    }  
