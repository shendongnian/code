    public abstract class M16
    {
        private Scope scope; = getScope();
        private SecondaryWeapon secondary = getSecondaryWeapon();
        private Camouflage camo; = getCamouflage();
        public double getMass()
        {
            // Add the mass of the gun to the mass of all the attachments.
        }
        public Point2D shootAtTarget(Point2D targetPosition)
        {
            // Very complecated calculation taking account of lots of variables such as
            // scope accuracy and gun weight.
        }
    
        // Don't have to be abstract if you want to have defaults.
        protected abstract Scope getScope();
        protected abstract SecondaryWeapon getSecondaryWeapon();
        protected abstract Camouflage getCamouflage();
    }
    //Then, your new JungleM16 can be created with hardly any effort (and importantly, no code //copying):
 
    public class JungleM16 : M16
    {
        public Scope getScope()
        {
            return new NightVisionScope();
        }
 
        public SecondaryWeapon getSecondaryWeapon()
        {
            return new GrenadeLauncher();
        }
        public Camouflage getCamouflage()
        {
            return new JungleCamo();
        }
    }
