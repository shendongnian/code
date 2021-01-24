    public IList<CustomerModelQB> GetAllCustomer(string fromName = "a", string toName = "z", bool IsActiveOnly = true)
        {
            RequestMsgSet.ClearRequests();
            ICustomerQuery CustomerQueryRq = RequestMsgSet.AppendCustomerQueryRq();
            if (IsActiveOnly)
            {
                if (CustomerQueryRq != null)
                    CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(
                        ENActiveStatus.asActiveOnly);
            }
            else
                CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asAll);
            //CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.MaxReturned.SetValue(3);
            //Set field value for FromName
            CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue(fromName);
            //Set field value for ToName
            CustomerQueryRq.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue(toName);
            CustomerQueryRq.IncludeRetElementList.Add("FullName");
            CustomerQueryRq.IncludeRetElementList.Add("AccountNumber");
            ResponseMsgSet = SessionManager.DoRequests(RequestMsgSet);
            return WalkCustomerQuery(ResponseMsgSet);
        }
