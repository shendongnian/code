    public void OnDeath()
         {
             Debug.Log("on death started");//debug
             isDead = true;
             if (PlayerPrefs.GetFloat("Highscore") < score)
             PlayerPrefs.SetFloat("Highscore", score);
             deathMenu.ToggleEndMenu(score);
             Debug.Log("on death finished");//debug
         }
    public void ToggleEndMenu(float score)
         {
             Debug.Log("toggle end menu called with score"+score);//debug
             gameObject.SetActive(true);
             scoreText.text = ((int)score).ToString();
             isShown = true;
             Debug.Log("toggle end menu finished");//debug
         }
     void Update()
     {
           if (transform.position.y < -1)
             {              
             Debug.Log("calling death from update started");//debug
             Death();
             Debug.Log("calling death from update finished"); //debug
         }
     }
 
    private void OnControllerColliderHit(ControllerColliderHit hit)
         {
             Debug.Log("on colliderhit entered");//debug
             if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")
             {
                 Death();
             }
    Debug.Log("on colliderhit finished");//debug
         }
    
         private void Death()
         {
            Debug.Log("on death entered");//debug
             isDead = true;
             GetComponent<PlayerScore>().OnDeath();
               Debug.Log("on death finished");//debug
         }
