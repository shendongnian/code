    if (!Page.IsPostBack)
        {
            if (FormView1.DataItemCount == 0)
            {
                FormView1.ChangeMode(FormViewMode.Insert);
            }
        }
