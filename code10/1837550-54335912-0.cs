    public abstract class SpaceshipController 
    {
        // already has an implementation but might be extended or overruled
        protected virtual void updateSpaceshipMovement()
        {
            // do something general
        }
        // does not have an implementation -> HAS to be implemented by subclass
        protected abstract void Something();
    }
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
