    [HttpPost]
    private async Task<bool> AcceptPostOrder(MachinePostModel Order)
    {
    	MachinePostModel OrderDetails = new MachinePostModel();
    	try
    	{
    		OrderDetails.ID = 1163;
    		OrderDetails.joStatus = "should to wait";
    		OrderDetails.remarks = "hello remarks";
    
    		var Client = await Services.MachineTestPostService.PostOrderAsync(OrderDetails);
    			return true;
    	}
    	catch (Exception exc)
    	{
    		await MachineTestOrderView.machineobj.DisplayAlert("Alert", exc.Message, "OK");
    		return false;
    	}
    }
