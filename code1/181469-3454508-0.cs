            string[][] CREATECUSTOMERCOMMANDSET = new string[][] { new string[] { "CustomerView", "CreateCustomer", "UpdateCustomer", "DeleteCustomer" } };
            Interprise.Framework.Base.DatasetGateway.Customer.NewCustomerDetailDatasetGateway customerDataset = new Interprise.Framework.Base.DatasetGateway.Customer.NewCustomerDetailDatasetGateway();
            Interprise.Facade.Base.Customer.NewCustomerDetailFacade customerDetailFacade = new Interprise.Facade.Base.Customer.NewCustomerDetailFacade(customerDataset);
            customerDetailFacade.AddCustomer(customerCode, customerName, Convert.ToBoolean(isProspect), businessType);
            return customerDetailFacade.UpdateDataSet(CREATECUSTOMERCOMMANDSET, Interprise.Framework.Base.Shared.Enum.TransactionType.CustomerDetail, "Create a new Customer", false);
        }
        #endregion
        #region Update Function/s
        [WebInvoke(UriTemplate = "customer/update/{customerCode}/customerName={customerName}/isProspect={isProspect}/businessType={businessType}", Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare)]
        public bool UpdateCustomer(string customerCode, string customerName, string isProspect, string businessType)
        {
            try
            {
                string[][] UPDATECUSTOMERCOMMANDSET = new string[][] { new string[] { "CustomerView", "CreateCustomer", "UpdateCustomer", "DeleteCustomer" } };
                CustomerDetailDatasetGateway gateway = new CustomerDetailDatasetGateway();
                CustomerDetailFacade facade = new CustomerDetailFacade(gateway);
                string[][] CUSTOMERPARAMETERS = new string[][] { new string[] { "@CustomerCode", customerCode } };
                facade.LoadDataSet(new string[][] { new string[] { "CustomerView", "ReadCustomer" } }, CUSTOMERPARAMETERS, Interprise.Framework.Base.Shared.Enum.ClearType.Specific, Interprise.Framework.Base.Shared.Enum.ConnectionStringType.Online);
                gateway.CustomerView[0].CustomerName = customerName;
                gateway.CustomerView[0].IsProspect = Convert.ToBoolean(isProspect);
                return facade.UpdateDataSet(UPDATECUSTOMERCOMMANDSET, Interprise.Framework.Base.Shared.Enum.TransactionType.CustomerDetail, "Update Customer", false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Delete Function/s
        [WebInvoke(UriTemplate = "customer/delete/customerCode={customerCode}", Method = "DELETE")]
        public bool DeleteCustomer(string customerCode)
        {
            System.IO.File.WriteAllText("D:\\asdf.txt", "working");
            string[][] DELETECUSTOMERCOMMANDSET = new string[][] { new string[] { "CustomerView", "CreateCustomer", "UpdateCustomer", "DeleteCustomer" } };
            CustomerDetailDatasetGateway gateway = new CustomerDetailDatasetGateway();
            CustomerDetailFacade customerFacade = new CustomerDetailFacade(gateway);
            string[][] CUSTOMERPARAMETERS = new string[][] { new string[] { "@CustomerCode", customerCode } };
            customerFacade.LoadDataSet(new string[][] { new string[] { "CustomerView", "ReadCustomer" } }, CUSTOMERPARAMETERS, Interprise.Framework.Base.Shared.Enum.ClearType.Specific, Interprise.Framework.Base.Shared.Enum.ConnectionStringType.Online);
            customerFacade.DeleteCustomer();
            return customerFacade.UpdateDataSet(DELETECUSTOMERCOMMANDSET, Interprise.Framework.Base.Shared.Enum.TransactionType.CustomerDetail, "Delete Customer", false);
        }
