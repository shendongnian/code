    public class A
    {
        public string Display { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var list = new List<A>();
        var a = new A();
        a.Display = "<script>alert('hi')</script>S<br/>";
        list.Add(a);
        rep.DataSource = list;
        rep.DataBind();
    }
