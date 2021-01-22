    namespace Foo 
    {   
        public interface INode
        {
            string Speak();
        }
    
        public abstract class AbstractRoot<T> where T : INode
        {
            public abstract IList<T> Children { get; set; }
        }
    
        public class GammaChild : INode
        {
            public string Speak() { return "I am GammaNode."; }
        }
    
        public class BetaChild : INode
        {
            public string Speak() { return "I am BetaNode."; }
        }
    
        public class AlphaRoot<T> : AbstractRoot<T>, INode where T : BetaChild
        {
            public string Speak() { return "I am AlphaRoot."; }
    
            private IList<T> children;
            public override IList<T> Children { get { return children; } set { children = value; } }
        }
    
        public class Test
        {
            public void Run()
            {
                AlphaRoot<BetaChild> alphaBetaTree = new AlphaRoot<BetaChild>();
                alphaBetaTree.Children.Add(new BetaChild());
    
                AlphaRoot<GammaChild> alphaGammaTree = new AlphaRoot<GammaChild>();
                alphaGammaTree.Children.Add(new GammaChild());
            }
        }
    }
