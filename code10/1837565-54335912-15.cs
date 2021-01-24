    public class ExampleController : SpaceshipController 
    {
        // I don't have to implement updateSpaceshipMovement
        // but I want to extend or overwrite it
        protected override void updateSpaceshipMovement()
        {
            // optional: anyway execute base code
            base.updateSpaceshipMovement();
            // do other stuff
        }
        // I have to implement this
        protected override void Something()
        {
            // do something
        }
    }
