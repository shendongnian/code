    class XYNode {
        protected int mX;
        protected int mY;
    
        public override bool Equals(Object obj) {
            if (obj == null || this.GetType() != obj.GetType()) { return false; }
            XYNode otherNode = (XYNode)obj;
            return (this.mX == other.mX) && (this.mY == other.mY);
        }
    }
