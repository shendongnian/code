    public class SomeClass
    {
        public SomeClass(bool c, string n, int id)
        {
            IsCool = c;
            Name = n;
            Id = id;
        }
        public bool IsCool { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
    .
    .
    .
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<SomeClass> people = new List<SomeClass>();
            people.Add(new SomeClass(true, "Will", 666));
            people.Add(new SomeClass(true, "Dan", 2));
            people.Add(new SomeClass(true, "Lea", 4));
            people.Add(new SomeClass(false, "Someone", 123));
            Repeater1.DataSource = people;
            Repeater1.DataBind();
        }
    }
    private void CheckChanged(int id)
    {
        Response.Write("CheckChanged called for item #" + id.ToString());
    }
    protected void ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        //this needs to be set again on post back
        CheckBox chk = (CheckBox)e.Item.FindControl("chkCool");
        Literal arg = (Literal)e.Item.FindControl("litArg");
        Action<object, EventArgs> handler = (s, args) => CheckChanged(Convert.ToInt32(arg.Text));
        chk.CheckedChanged += new EventHandler(handler);
    }
