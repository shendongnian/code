        using (AppraisalsLenderXDataContext db = new AppraisalsLenderXDataContext(ConfigurationManager.ConnectionStrings["AppraisalsLenderX"].ConnectionString))
    {
        LenderXMessage message = new LenderXMessage();
        message.EventType = lxEvent.EventType.Substring(0, lxEvent.EventType.Length);
        message.EventID = lxEvent.EventID.Substring(0, lxEvent.EventID.Length);
        message.AppraisalOrderID = lxEvent.LXData.AppraisalOrder.AppraisalOrderID.Substring(0, lxEvent.LXData.AppraisalOrder.AppraisalOrderID.Length);
        message.LoanNumber = lxEvent.LXData.AppraisalOrder.LXAppFile.LoanNumber.Substring(0, lxEvent.LXData.AppraisalOrder.LXAppFile.LoanNumber.Length);
        message.OrderStatus = lxEvent.LXData.AppraisalOrder.OrderStatus.Substring(0, lxEvent.LXData.AppraisalOrder.OrderStatus.Length);
        message.LoanOfficerEmailAddress = lxEvent.LXData.AppraisalOrder.LoanOfficerInfo.LoanOfficerAccount.Substring(0, lxEvent.LXData.AppraisalOrder.LoanOfficerInfo.LoanOfficerAccount.Length);
        message.DateCreated = DateTime.Now;
        db.LenderXMessages.InsertOnSubmit(message);
        try
        {
            db.SubmitChanges();
        }
        catch (Exception ex)
        {
            log.Error($"Error attempting to insert a record into AppraisalsLenderX database ... StackTrace: {ex.ToString()}");
        }
    }
