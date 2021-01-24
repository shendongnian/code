    public void DealDmg()
    {
        if (attackPos.gameObject.activeSelf == true)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemyScript = enemiesToDamage[i].GetComponent<EnemyScript>();
                enemyScript.TakeDmg(damage);
                if (facingRight == true)
                {
                    enemyScript.GetComponent<RigidBody>().AddForce(transform.up * 500 + transform.right * 500);
                }
                else if (facingRight == false)
                {
                    enemyScript.GetComponent<RigidBody>().AddForce(transform.up * 500 + (transform.right * 500) * -1);
                }
                attackPos.gameObject.SetActive(false);
            }
        }
    }
