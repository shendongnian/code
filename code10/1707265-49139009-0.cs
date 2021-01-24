    var ans = (from a in dbo.BILL_INFO_DETAIL
               join b in dbo.SERVICE_INFO on a.SERVICE_CODE equals b.SERVICE_CODE
               join p in dbo.PAY_MODE on a.PAY_MODE_ID equals p.PAY_MODE_ID
               where (a.INPUT_STATUS == "1") &&
                     (new[] { 1610, 1611, 1612 }.Contains(b.SERVICE_CODE)) &&
                     (new[] { 10, 11, 12 }.Contains(a.STAMP_DATE.Month)) &&
                     (new[] { 2017 }.Contains(a.STAMP_DATE.Year)) &&
                     (b.FEE > 1)
               let TransactionType = new[] { 1, 2 }.Contains(a.PAY_MODE_ID) ? "OFFLINE" : "ONLINE"
               group new { a, b, p } by new { bName = b.NAME, TransactionType, pName = p.NAME } into abpg
               orderby abpg.Key.TransactionType
               select new {
                   Service_Name = abpg.Key.bName,
                   TransactionType = abpg.Key.TransactionType,
                   Payment_Method = abpg.Key.pName,
                   Transaction = abpg.Sum(abp => abp.a.REQUESTED_QTY),
                   Income = abpg.Sum(abp => abp.a.ITEM_TOTAL)
               }).Distinct();
