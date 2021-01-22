    public interface ILinkedListNode
    {
        ILinkedListNode Next { get; set; }
        ILinkedListNode Previous { get; set; }
    }
    public class LinkedList<T> where T : ILinkedListNode 
    {
        /*.... methods here ...*/
    }
    public class Node : ILinkedListNode
    {
        public Node Next { get; set; }
        public Node Previous { get; set; }
        ILinkedListNode ILinkedListNode.Next
        {
            get { return this.Next; }
            set { this.Next = (Node)value; }
        }
        ILinkedListNode ILinkedListNode.Previous
        {
            get { return this.Previous; }
            set { this.Previous = (Node)value; }
        }
    }
