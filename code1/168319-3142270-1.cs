    public class KDTree<MDT> {
        // ... 
        public MDT Data { get; }
    }
    var twoTree = new KDTree<string[,]>();
    twoTree.Data[3,4] = "X,Y = (3,4)";
