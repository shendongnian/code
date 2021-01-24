    void Page_Load(object sender, EventArgs e )
    {
         // don`t use if(!IsPostBack) because every postback your contols leave and you must register your controls.
         list=new List<Item>();
         list.Add(...);
         list.Add(...);
         list.Add(...);
    }
