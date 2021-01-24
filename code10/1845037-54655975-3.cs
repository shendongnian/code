    public abstract class ProbNode
    {
        public ProbNode[] ChildNodes { get; set; }
        public abstract double ThisProbability(); // In case it is a leaf node.
        public double OverallProbablility()
        {
            if (ChildNodes == null || ChildNodes.All(n => n == null)) {
                // We have a leaf node
                return ThisProbability();
            } else {
                // We have an internal node.
                // Get the probability as product of the probabilities of the child nodes.
                double p = 1.0;
                foreach (ProbNode child in ChildNodes) {
                    if (child != null) {
                        p *= child.OverallProbablility(); // <== Recursive call.
                    }
                }
                return p;
            }
        }
    }
