            //  Label1.Text = "if";
            pnl1.Visible = true;
            pnl2.Visible = false;
            btnSave.Visible = false;
        }
        else
        {
            btnSave.Visible = true;
            pnl1.Visible = false;
            pnl2.Visible = true;
            ibnext.Visible = false;
            // Label1.Text = "else";
        }
        upPanels.Update(); //update view
