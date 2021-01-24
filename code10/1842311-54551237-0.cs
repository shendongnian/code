    public enum QuestionCategories 
    {
        None,
        visualInspection
    }
    
    public abstract partial class ClientTreeNode {
        public int ID { get; internal set; }
        public string Question { get; internal set; }
        public List<ClientTreeNode> Children { get; internal set; }
        public QuestionCategories Category { get; internal set; }
        public Dictionary<object, int[]> AnswerNodes { get; internal set; }
    }
    
    public class YesNoTreeNode : ClientTreeNode {
        public bool Result { get; internal set; }
    
    }
    
    void Main()
    {
        var json="{'Result':false,'ID':0,'Question':null,'Children':null,'Category':'visualInspection','AnswerNodes':{'True':[4],'False':[5]},'Type':'yesNo','CategoryText':'Sichtprüfung'}";
        var obj=JsonConvert.DeserializeObject<YesNoTreeNode>(json);
        JsonConvert.SerializeObject(obj).Dump();
    }
