        var checkDMS = CheckIfNull(dealtxt.Text);
        if (checkDMS)
        {
            //If DMS Deal is valid -> If Form is Closed -> 
            if (form2.IsDisposed)
            {
                // If Form not open -> Create new instance 
                form2 = new Form2();
                form2.Show();
                form2.SendToBack();
            }
            else
            {
                // If Form still open -> Close and make new instance.
                form2.Close();
                form2 = new Form2();
                form2.Show();
                form2.SendToBack();
            }
            runDMSQueryFromNewThread(materialCheckBox1.Checked);
        }
        else
        {
            MessageBox.Show("Cannot Pull Deal From DMS.");
        }
