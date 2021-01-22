    protected override void OnOpening()
    {
        base.OnOpening();
        this.Description.Behaviors.Add(new UserNamePasswordServiceCredentials());
    }
