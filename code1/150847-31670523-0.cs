    Infragistics.Web.UI.DataSourceControls.DataView dvMesaj = new Infragistics.Web.UI.DataSourceControls.DataView();
            
            whdsShowMessages.DataRelations.Clear();
            whdsShowMessages.DataViews.Clear();
            whgridShowMessages.Rows.Clear();
            EnableViewState = false; //here is the solution..
            whdsShowMessages.DataViews.Add(dvKisi);
            whdsShowMessages.DataViews.Add(dvMesaj);
