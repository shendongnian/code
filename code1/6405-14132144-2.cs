    interface INode
    {
        void Action;
    }
        
    class Bob
    {
        public void Action
        {
        }
    }
    class Jill
    {
        public void Action
        {
        }
    }
    class Marko
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
