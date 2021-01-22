        protected void Page_Load(object sender, EventArgs e)
        {
            Textbox1.Attributes.Add("onblur","Validate();");
        }
    }
