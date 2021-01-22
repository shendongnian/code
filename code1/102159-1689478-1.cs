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
    
        public class BetaChild : AbstractRoot<BetaChild>, INode
        {
            public string Speak() { return "I am BetaNode."; }
            public string BetaSpeak() { return "I am talking Beta-specific things."; }
    
            private IList<BetaChild> children;
            public override IList<BetaChild> Children { get { return children; } set { children = value; } }
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
    
                alphaBetaTree.Children[0].BetaSpeak();
    
                AlphaRoot<GammaChild> alphaGammaTree = new AlphaRoot<GammaChild>();
                alphaGammaTree.Children.Add(new GammaChild());
            }
        }
    }
