    public ActionResult GetFile() // note should accept an id or something
    {
        byte[] bytes = null;
        conn.Open();
        using (SqlCommand cmd1 = new SqlCommand("select  isnull(ClientPic,'') as ClientPic from MembersDetail where Srno=1 and MemberShipID='" + clsCommon._MembershipID + "'", conn))
        {
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter ad = new SqlDataAdapter(cmd1);
            DataTable mdt_pic = new DataTable();
            ad.Fill(mdt_pic);
            for (int i = 0; i < mdt_pic.Rows.Count; i++)
            {
                 bytes = (byte[])mdt_pic.Rows[i]["ClientPic"];
            }
            conn.Close();
        }
        return new FileContentResult(bytes, "image/png"); // content type may be different for any file
    }
