    public class Toolbox
    {
        readonly Hammer hammer;
        readonly Screwdriver screwdriver;
        public Toolbox(params Tool[] tool)
        {
            foreach (Tool t in tool)
            {
                if (t is Hammer hammer)
                {
                    this.hammer = hammer;
                }
                if (t is Screwdriver screwdriver)
                {
                    this.screwdriver = screwdriver;
                }
            }
        }
    #region Properties       
        public Screwdriver Screwdriver => screwdriver;
        public Hammer Hammer => hammer;
        public bool HasHammer => hammer != null;
        public bool HasScrewdriver => screwdriver != null;
    #end region
    }
