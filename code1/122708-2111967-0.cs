    int targetId;
    if (Int32.TryParse(tbxMember.Text, out targetId)) {
        int logincheck = (from r in lg.tblOnlineReportingLogins
                      where r.MemberID == tbxMember.Text.ToString()
                      select r).Count();
        // ...
    } else {
        MessageBox.ShowMessage("Invalid Id");
    }
