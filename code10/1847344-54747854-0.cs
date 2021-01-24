    public void OnKeyDown()
    {
         anim.SetTrigger("loading");
         aura.AuraStart();
    }
    public void OnKeyUp()
    {
            anim.SetTrigger("attacking");
            if (aura.IsLoaded()) 
            {
                // Para que se mueva desde el principio tenemos que asignar un
                // valor inicial al movX o movY en el edtitor distinto a cero
                float angle = Mathf.Atan2(anim.GetFloat("movY"), anim.GetFloat("movX")) * Mathf.Rad2Deg;
    
                GameObject slashObj = Instantiate(slashPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
    
                Slash slash = slashObj.GetComponent<Slash>();
                slash.mov.x = anim.GetFloat("movX");
                slash.mov.y = anim.GetFloat("movY");
            }
    
            aura.AuraStop();
            StartCoroutine(EnableMovementAfter(0.4f));
    }
    void SlashAttack () 
    {
        // We look for the current state looking at the information of the animator
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool loading = stateInfo.IsName("Player_Slash");
    
        // Ataque a distancia
        if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Z))
        { 
           OnKeyDown();
        } 
        else if (Input.GetKeyUp("p") || Input.GetKeyUp(KeyCode.Z))
        { 
            OnKeyUp();
        } 
    
        // Prevenimos el movimiento mientras cargamos
        if (loading) 
        { 
            movePrevent = true;
        }
    }
