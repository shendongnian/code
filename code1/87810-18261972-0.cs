        protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            CheckBoxList cbl = (CheckBoxList)e.Item.FindControl("CheckBoxList1");
            cbl.SelectedIndexChanged += new EventHandler(chkLinked_CheckedChanged);
            string name = "";
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.Items[i].Selected)
                {
                    name += cbl.Items[i].Text.Split(',')[0] + ",";
                }
            }
        }
