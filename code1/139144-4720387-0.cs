            protected void ldsAssets_Draft_Load(object sender, EventArgs e) {
                string Where_Statement = " Planner_ID == @Planner_ID";
                ldsAssets_Draft.WhereParameters.Add("Planner_ID", System.Data.DbType.Int32, User_ID.ToString());
                if (this._DraftOrderStatus != BusinessLogic.DraftOrderStatus.All) {
                    Where_Statement += " AND Status_ID == @Status_ID";
                    ldsAssets_Draft.WhereParameters.Add("Status_ID", System.Data.DbType.Int32,     ((int)this._DraftOrderStatus).ToString());
                }
                ldsAssets_Draft.Where = Where_Statement;
            }
