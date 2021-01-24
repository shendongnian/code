    public ExampleController : SpaceshipController 
    {
        // I don't have to implement updateSpaceshipMovement
        // but I want to extend or overwrite it
        // you can keep it virtual so further subclasses may also extend this
        protected override virtual void updateSpaceshipMovement()
        {
            // optional: anyway execute base code
            base.updateSpaceshipMovement();
            // do other stuff
        }
        // I have to implement this
        // you can keep it virtual so further subclasses may also extend this
        protected virtual override void Something()
        {
            // do something
        }
    }
