    public interface EntityVisitor
    {
        void Visit(Arc arc);
        void Visit(Line line);
    }
    public abstract class Entity
    {
        public abstract void Accept(EntityVisitor visitor);
    }
    public class Arc : Entity
    {
        protected double startx;
        protected double starty;
        protected double endx;
        protected double endy;
        protected double radius;
        public override void Accept(EntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Line : Entity
    {
        protected double startx;
        protected double starty;
        protected double endx;
        protected double endy;
        protected double length;
        public override void Accept(EntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
