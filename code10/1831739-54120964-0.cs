	public PurchaseOrderPreliminaryDesignViewModel GetPreliminaryDesignList(string jobNumber)
	{
		try
		{
			PurchaseOrderPreliminaryDesignViewModel DoGetDesigns()
			{
				using (var connection = _connectionManager.GetOpenConnection(_configuration.GetConnectionString(FirstConnectionString)))
				using (var connection2 = _connectionManager.GetOpenConnection(_configuration.GetConnectionString(SecondConnectionString)))
				{
					var rModel = new PurchaseOrderPreliminaryDesignViewModel();
					var designList = connection.Query<PurchaseOrderPreliminaryDesignModel>("[dbo].[usp_PurchaseOrder_Preliminary_Design]", param: new
					{
						LegacyKey = jobNumber
					}, commandType: CommandType.StoredProcedure);
					
					var vendorList = connection2.Query<PurchaseOrderPreliminaryVendorModel>("mystore", param: new
					{
						Parameter = jobNumber
					}, commandType: CommandType.StoredProcedure);
				
					rModel.AddDesignList(designList).AddVendorList(vendorList);					
					
					return rModel;
				}
			}
			return DoGetDesigns();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
		
