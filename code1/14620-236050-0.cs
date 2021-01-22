    string Name
    {
       get 
       {
           if(Session["Name"] == Null)
               Session["Name"] = "Default value";
           return (string)Session["Name"];
       }
       set { Session["Name"] = value; }
    }
}
