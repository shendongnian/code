            protected void ListView1_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DataRow myRow;
            DataRowView myRowView;
            myRowView = (DataRowView)e.Item.DataItem;
            myRow = myRowView.Row;
            System.Web.UI.HtmlControls.HtmlTableRow myTR = (System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("trRow");
            if (myRow[2].ToString().CompareTo("") == 1)
            {
                myTR.Style.Value = "background-color:#FF0000;color: #000000;";
            } else
                myTR.Style.Value = "background-color:#00FF00;color: #000000;";
        }
