    using(mockRepository.Playback())
    {
        controller = new LockClassPanelController( sessionFactory ); 
        controller.AddLockClass( lockClass.Id, string.Empty );
    }
    
    mockRepository.VerifyAll();
