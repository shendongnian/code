    void SwitchDirection()
    {
       if (rb.velocity.z > 0)
       {
           bool platformInXplus = Physics.CheckBox(transform.position + Vector3.right * size, Vector3.one * .1f + Vector3.up * 2f, Quaternion.identity, /*layermask*/ 0, QueryTriggerInteraction.UseGlobal); 
           if(platformInXplus)
           {
               rb.velocity = new Vector3(speed, 0, 0);
           }
           else
           {
               rb.velocity = new Vector3(-speed, 0, 0);
           }
       }
       else if(Mathf.Abs(rb.velocity.x) > 0f)
       {
           rb.velocity = new Vector3(0, 0, speed);
       }
    }
