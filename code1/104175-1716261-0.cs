    public abstract class SpaceFactory
    {
        public static readonly SpaceFactory Space = new SpaceFactoryImpl();
        public static readonly SpaceFactory ZeroWidth = new ZeroWidthFactoryImpl();
        protected SpaceFactory { }
        public abstract char GetSpace();
        public virtual string GetSpaces(int count)
        {
            return new string(this.GetSpace(), count);
        }
        private class SpaceFactoryImpl : SpaceFactory
        {
            public override char GetSpace()
            {
                return '\u0020';
            }
        }
        private class ZeroWidthFactoryImpl : SpaceFactory
        {
            public override char GetSpace()
            {
                return '\u200B';
            }
        }
    }
