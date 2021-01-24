        public List<tbInvoiceHeader> GetInvoices(DateTime? fromDate, DateTime? toDate, bool fromModifiedDate, string invoiceNumber)
        {
            var invoices = new List<tbInvoiceHeader>();
            IMsgSetRequest requestMsgSet;
            IMsgSetResponse responseMsgSet;
            requestMsgSet = GetLatestMsgSetRequest();
            requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;
            
            IInvoiceQuery invoiceQuery = requestMsgSet.AppendInvoiceQueryRq();
            IInvoiceFilter invoiceFilter = invoiceQuery.ORInvoiceQuery.InvoiceFilter;
            if (!string.IsNullOrEmpty(invoiceNumber))
            {
                invoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(invoiceNumber);
                invoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcStartsWith);
            }
            else
            {
                if (fromDate.HasValue)
                {
                    if (!fromModifiedDate)
                    {
                        invoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fromDate.Value);
                    }
                    else
                    {
                        invoiceFilter.ORDateRangeFilter.ModifiedDateRangeFilter.FromModifiedDate.SetValue(fromDate.Value, asDateOnly: true);
                    }
                }
                if (toDate.HasValue)
                {
                    if (!fromModifiedDate)
                    {
                        invoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(toDate.Value);
                    }
                    else
                    {
                        invoiceFilter.ORDateRangeFilter.ModifiedDateRangeFilter.ToModifiedDate.SetValue(toDate.Value, asDateOnly: true);
                    }
                }
            }
            invoiceFilter.MaxReturned.SetValue(iterationNumber); // Set max returns element.
            invoiceQuery.iterator.SetValue(ENiterator.itStart);
            invoiceQuery.IncludeLinkedTxns.SetValue(true);
            invoiceQuery.IncludeLineItems.SetValue(true);   
            invoiceQuery.OwnerIDList.Add("0");              // To include customs fields
            responseMsgSet = mySessionManager.DoRequests(requestMsgSet);
            do 
            {
                //Step 5: Interpret the response
                IResponseList rsList = responseMsgSet.ResponseList;
                //Retrieve the one response corresponding to our single request
                IResponse response = rsList.GetAt(0);
                if (response.StatusCode == 0) //We have one or more invoices-> show them
                {
                    IInvoiceRetList invoiceList = response.Detail as IInvoiceRetList;
                    int maxCnt = invoiceList.Count;
                    if (invoiceProgressEvent != null)
                    {
                        invoiceProgressEvent(new ProgressEvent() { Count = maxCnt, RemainingCnt = response.iteratorRemainingCount, Invoices = invoices });
                    }
                    //for logging only
                    //XmlDocument doc = new XmlDocument();
                    //doc.LoadXml(responseMsgSet.ToXMLString());
                    //XmlNodeList nodes = doc.SelectNodes("//InvoiceRet");
                    for (int ndx = 0; ndx < maxCnt; ndx++)
                    {
                        //var xmlText = nodes[ndx].InnerXml;
                        IInvoiceRet invoiceRet = invoiceList.GetAt(ndx);
                        invoices.Add(GetInvoiceHeaderDetail(invoiceRet));
                    }
                }
                if (response.iteratorRemainingCount > 0)
                {
                    invoiceQuery.iteratorID.SetValue(response.iteratorID);
                    invoiceQuery.iterator.SetValue(ENiterator.itContinue);
                    responseMsgSet = mySessionManager.DoRequests(requestMsgSet);
                }
                else
                {
                    //This cause The iteratorID "..." is not valid.
                    //invoiceQuery.iteratorID.SetValue(response.iteratorID);
                    //invoiceQuery.iterator.SetValue(ENiterator.itStop);
                    //responseMsgSet = mySessionManager.DoRequests(requestMsgSet);
                    break;
                }
            } while (true);
            return invoices;
        }
