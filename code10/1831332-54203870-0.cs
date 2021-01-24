            List<Failure> failedOrders = new List<Failure>();
            foreach (String item in new List<string> { "1", "2", "3" })
            {
                failedOrders.Add(new Failure { externalItemCodeColumn = item, reasonColumn = "Not enough available items in WAREHOUSE" });
            }
            Sage.Common.Controls.GridColumn externalItemCodeColumn = new Sage.Common.Controls.GridColumn();
            externalItemCodeColumn.Caption = "External Item Code";
            externalItemCodeColumn.DisplayMember = "externalItemCodeColumn";
            Sage.Common.Controls.GridColumn reasonColumn = new Sage.Common.Controls.GridColumn();
            reasonColumn.Caption = "Reason";
            reasonColumn.DisplayMember = "reasonColumn";
            failedOrdersGrid.Columns.Add(externalItemCodeColumn);
            failedOrdersGrid.Columns.Add(reasonColumn);
            failedOrdersGrid.DataSource = failedOrders;
