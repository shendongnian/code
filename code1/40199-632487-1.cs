            var query = db.TagsHeaders
                .Where(tags => tags.CST.Equals(this.SelectedCust.CustCode.ToUpper()))
                .Where(tags => Utility.GetDate(DateTime.Parse(this.txtOrderDateFrom.Text)) <= tags.ORDDTE)
                .Where(tags => Utility.GetDate(DateTime.Parse(this.txtOrderDateTo.Text)) >= tags.ORDDTE)
                .WhereIf(condition1, tags => tags.PONumber == "ABC")
                .WhereIf(condition2, tags => tags.XYZ > 123);
