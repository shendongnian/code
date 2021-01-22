    public partial class TestUserControl: UserControl{
        public TestUserControl(){
    
        }
    
        public int Property1 { get; set; }
        public bool Property2 { get; set; }
        public string Property3 { get; set; }
        public List<object> Objects { get; set; }
    
        protected override OnLoad(EventArgs e){
            Objects = new List<object>(){
                Property1,
                Property2,
                Property3
            };
    
            foreach(var item in Objects){
                Page.Controls.Add(new Literal(item.ToString() + "<br/>"));
            }
        }
    }
