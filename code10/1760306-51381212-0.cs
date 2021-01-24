    protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int treatmendid;
            if (int.TryParse(btn.CommandArgument.ToString(), out treatmendid) == true)
            {
                var x = srvLogic.GetServiceById(treatmendid).AsEnumerable().First();
                if (x != null)
                {
                    txtNewTreatmentName.Text = x.Field<string>("ServiceName");
                    txtNewTreatmentShortDesc.Text = x.Field<string>("ServiceShortDescription");
                    txtNewTreatmentPrice.Text = x.Field<string>("ServiceCost");
                    txtNewTreatmentLink.Text = x.Field<string>("ServiceTimelyLink");
                    txtNewTreatmentLongDesc.Text = x.Field<string>("ServiceLongDescription");
                    btnAddServ.Text = "Update treatment info";
                    btnAddServ.ToolTip = x.Field<int>("ServiceId").ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "success", "$('#myTreatmentModal').modal('show');", true);
                }
            }
        }
