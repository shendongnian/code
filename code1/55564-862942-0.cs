            Panel pTest = new Panel();
            TextBox tb = new TextBox();
            for (int i = 0; i < 2; i++)
            {
                tb.ID = "tbDynamicTextBox" + i;
                pTest.Controls.Add(tb );
                RequiredFieldValidator rfv = new RequiredFieldValidator();
                rfv.ControlToValidate = tb.ID;
                rfv.ErrorMessage = "Empty textbox";
                pTest.Controls.Add(rfv);
            }
            cell.Controls.Add(pTest);
