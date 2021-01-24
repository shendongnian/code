    private interuptRoutine = false;
    public void Interact()
    {
        if (Vector3.Distance(Player.MyInstance.MyTransform.position, transform.position) < interactDistance && Player.MyInstance.MyHasPickaxe == true)
        {
            playerPosition = Player.MyInstance.MyTransform.position;
            // before starting the routine set the interupt flag to false
            interuptRoutine = false;
            StartCoroutine(Gather(timeToGather));
        }
        else
        {
            GameManager.MyInstance.SendMessageToChat("You need to equip a 'Pickaxe' to mine this resource.", Message.MessageType.warning);
        }
    }
    public void StopInteract()
    {
        Player.MyInstance.MyIsGathering = false;
        Player.MyInstance.animator.SetBool("Mining", Player.MyInstance.MyIsGathering);
        if (gatherRoutine != null)
        {
            // only set the interupt flag
            interuptRoutine = true;
        }
    }
    private IEnumerator Gather(float time)
    {
        Player.MyInstance.MyIsGathering = true;
        Player.MyInstance.animator.SetBool("Mining", Player.MyInstance.MyIsGathering);
        // does the same as WaitForSeconds but manually and interupts the routine
        // if interuptRoutine was set to true
        var timePast = 0;
        while(timePast <= time)
        {
            if(interuptRoutine) yield brake;
            timePast += Time.deltaTime;
        }
        
        Player.MyInstance.MyIsGathering = false;
        Player.MyInstance.animator.SetBool("Mining", Player.MyInstance.MyIsGathering);
        lootTable.ShowLoot();
        if (achievementName != null)
        {
            AchievementManager.MyInstance.EarnAchievement(achievementName);
        }
        Destroy(gameObject);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
