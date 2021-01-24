        if (Directory.GetFiles(Dts.Variables["User::Tech_Dim"].Value.ToString(), "*").Length > 0)
        {
            Dts.Variables["User::Dim_File_Count"].Value = 0;
            MessageBox.Show("folder empty");
        }
        else
        {
            Dts.Variables["User::Dim_File_Count"].Value = 1;
            MessageBox.Show("folder is not empty");
        }
