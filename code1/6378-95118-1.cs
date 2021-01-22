    class Node
    {
        public virtual void Action()
        {
            // Perform default action
        }
    }
    class Bob : Node
    {
        public override void Action()
        {
            // Perform action for Bill
        }
    }
    class Jill : Node
    {
        public override void Action()
        {
            // Perform action for Jill
        }
    }
