     class txtBox : ITemplate
     {
        public void InstantiateIn(System.Web.UI.Control container)
        {           
            System.Web.UI.WebControls.TextBox txt= new System.Web.UI.WebControls.TextBox();
            txt.ID = "123";         
            container.Controls.Add(txt);
        }
     } 
