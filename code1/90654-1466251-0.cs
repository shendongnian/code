    protected void pnlUpdate_PreRender(object sender, EventArgs args)
    {
        if (Request["__EVENTTARGET"] == pnlUpdate.ClientID)
        {
            PreBind();
            switch(Request["__EVENTARGUMENT"])
            {
                case "toggle":
                    Toggle();
                    break;
                case "purchase":
                    Purchase();
                    break;
                case "update":
                    /* nop */
                    break;
            }
            Bind();
        }
    }
