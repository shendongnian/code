    var query = from tags in db.TagsHeaders
                    where tags.CST.Equals(this.SelectedCust.CustCode.ToUpper()) 
                    && Utility.GetDate(DateTime.Parse(this.txtOrderDateFrom.Text)) <= tags.ORDDTE
                    && Utility.GetDate(DateTime.Parse(this.txtOrderDateTo.Text)) >= tags.ORDDTE
                    select tags;
