    public void StopInteract()
    {
        Player.MyInstance.MyIsGathering = false;
        Player.MyInstance.animator.SetBool("Mining", Player.MyInstance.MyIsGathering);
        if (gatherRoutine != null)
        {
            StopAllCoroutines();
        }
    }
