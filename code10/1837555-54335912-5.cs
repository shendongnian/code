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
