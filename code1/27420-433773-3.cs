    int num_flds;
        if(!int.TryParse(a_fld.Text,out num_flds))
        {
            num_flds = 0;
        }
        for (int i = 0; i < num_flds; i++)
        {
                TextBox tmp = new TextBox();
                tmp.ID = "answer_box" + i;
                tmp.Width = Unit.Pixel(300);
                answer_inputs.Controls.Add(tmp);
                tmp.TextChanged += tmp_TextChanged;
        }
