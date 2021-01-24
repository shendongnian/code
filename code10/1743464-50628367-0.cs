    public class DialogueNode {
        public int NodeID = -1; //I use -1 as a way to exit a conversation.
        //NodeId should be a positive number
        public string Text;
        public List<DialogueOption> Options;
    }
