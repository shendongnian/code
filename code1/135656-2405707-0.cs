     private void BindBulletList()
         {
             List<string> list = new List<string>();
             list.Add("item1");
             list.Add("item2");
             list.Add("item3");
             list.Add("item4");
             list.Add("item5");
    
             bullets.DataSource = list;
             bullets.DataBind();
    
             foreach (ListItem item in bullets.Items)
             {
                 item.Attributes.Add("Id", "li_" + item.Text);
             }
    
    
         }
