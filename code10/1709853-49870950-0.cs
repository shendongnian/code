        // Update "DateRecordLastUpdated" in GUI because changes have been made to the Process' fields.
        // Get the entity's primary key from the GUI and use it to Find the corresponding entity in the CollectionView.
        int OrgUnitID = int.Parse(viewAsset_assetOrgUnitIDTextBox.Text);
        int AssetClassID = int.Parse(viewAsset_assetAssetClassIDTextBox.Text);
        int AssetID = int.Parse(viewAsset_assetIDTextBox.Text);
        var selectedEntity = rmsDb.Assets.Find(OrgUnitID, AssetClassID, AssetID);       // Primary key components must be in sequence.
        rmsDb.Entry(selectedEntity).Property(u => u.DateRecordLastUpdated).CurrentValue = DateTime.UtcNow;
        BindingOperations.GetBindingExpression(viewAsset_dateRecordLastUpdated, TextBox.TextProperty).UpdateTarget();           //Trigger GUI binding refresh
        rmsDb.SaveChanges(); 
