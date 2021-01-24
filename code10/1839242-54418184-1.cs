     ImageButton LB1 = (ImageButton)e.Row.FindControl("SuperSButton");
            LB1.Visible = false;
            if (line.SuperSessionFlag)
            {
                if(line.SuperSessionIndicator == "1" || line.ErrorType =="S" )
                {
                    LB1.CommandArgument = line.PartNumber;
                    LB1.Visible = true;
                }
