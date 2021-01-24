    public class Warrior_Movement : BaseMovement
    {
        // Inherits all fields of BaseMovement
        //... additional type specific stuff
        // If you have abstract methods in the base class
        // every subclass has to implement all of them
        public override string SaySomething()
        {
            return "Harr harr, I'm a warrior!";
        }
    }
    public class Other_Movement : BaseMovement
    {
        // Inherits all fields of BaseMovement
        // Additional type specific stuff
        public override string SaySomething ()
        {
            return "Harr harr, I'm ... something else :'D ";
        }
    }
