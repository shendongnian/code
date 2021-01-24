    public interface IDataHelper {
        List<Data> GetData();
        void MoveNodes(int[] nodeKeys, int parentID);
        void MoveNode(int nodeID, int parentID);
        void MakeParentNodeRoot(int id);
    }
