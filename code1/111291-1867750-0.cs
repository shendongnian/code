    public partial class TestUserControl: UserControl{
    public TestUserControl(){
        Objects = new List<Func<object>>(){
            () => Property1,
            () => Property2,
            () => Property3
        };
    }
    public int Property1 { get; set; }
    public bool Property2 { get; set; }
    public string Property3 { get; set; }
    public List<Func<object>> Objects { get; set; }
    protected override OnLoad(EventArgs e){
        foreach(var item in Objects){
            Page.Controls.Add(new Literal(item().ToString() + "<br/>"));
        }
    }
}
