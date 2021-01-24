    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
          RaycastHit hit;
          if (Physics.Raycast(transform.position, transform.forward, out hit, RANGE))
          {
              IInteractable interactable = hit.collider.GetComponent<IInteractable>();
              if (interactable != null)
              {
                  interactable.ShowInteractability();
                  interactable.Interact();      
              }
          }
      }
    }
