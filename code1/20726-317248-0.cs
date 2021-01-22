     public ActionResult Add( string name ) {
        ....
     }
     or
     public ActionResult Add( FormCollection form ) {
          string name = form["Name"];
     }
     or
     public ActionResult Add( [Bind(Prefix="")]Villa villa ) {
           villa.Name ...
     }
