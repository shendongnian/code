    interface INode
    {
        void Action;
    }
        
    class Bob : INode
    {
        public void Action
        {
        }
    }
    class Jill : INode
    {
        public void Action
        {
        }
    }
    class Marko : INode
    {
        public void Action
        {
        }
    }
    //Your function:
    void Do(INode childNode)
    {
        childNode.Action();
    }
