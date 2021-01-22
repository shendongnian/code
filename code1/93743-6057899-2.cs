    public class M16
    {
        private Scope scope = new StandardScope();
        private SecondaryWeapon secondary = new Bayonet();
        private Camouflage camo = new DesertCamo();
        public double getMass()
        {
            // Add the mass of the gun to the mass of all the attachments.
        }
        public Point2D shootAtTarget(Point2D targetPosition)
        {
            // Very complecated calculation taking account of lots of variables such as
            // scope accuracy and gun weight.
        }
    }
