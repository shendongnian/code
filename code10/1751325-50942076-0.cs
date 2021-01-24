    string[] compID = new string[] { "0002", "0001", "0005", "0006" };
    string[] divisionCode = new string[] { "01021159", "02013350", "02013483", "02013804", "02013375", "02013374", "02013380", "02013398", "02017379", "02013391", "02013444", "02013353", "02004458", "02013394" };
    var ACM = (from t1 in Entity.ApprovedContracts
          join t2 in Entity.ApprovedResources
          on t1.ApprovedResourceId equals t2.ResourceGeneralId
          where compID.Contains(t1.OpuCode) && (t1.OpuCode == "0005" || t1.OpuCode == "0006" || divisionCode.Contains(t1.DivisionCode)
          select new
          {
                t1.OpuCode,
                t1.DivisionCode,
                t2.EnterpriseId,
                t2.ResourceEmail
          }).ToList();
