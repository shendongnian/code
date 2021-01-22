        if (Session["emp"] != null)
        {
            List<ListItem> name=(List<ListItem>)Session["emp"];           
            foreach (ListItem li in name)
            {
               Response.Write(li);
            }
        }
     }
