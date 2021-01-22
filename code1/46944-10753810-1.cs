        if(fileupload.HasFile)
        {
            string imageSrc = "~/Image/" +fileupload.PostedFile.FileName;
         string ImageName = txt1.Text;
        SqlConnection cn=new SqlConnection("uid=test;pwd=te$t;server=10.10.0.10;database=TestDB");
        cn.Open();
        string strSql = "Insert Into table6 (ImageName,Image) values ('" + ImageName + "','"+imageSrc+"')";
        SqlCommand cmd = new SqlCommand(strSql, cn);
        cmd.ExecuteNonQuery();
        cn.Close();
        BindData();
        txt1.Text = "";
    }
