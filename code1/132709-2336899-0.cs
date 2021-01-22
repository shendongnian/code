    private List<Control> ControlList = new List<Control>;
    
    private void CreateControls();
    {
        int i;
        for (i = 0; i < myCount; i += 1)
        {
            TextBox txtAuto = new TextBox();
            TextBox txtModel = new TextBox();
            TextBox txtMiles = new TextBox();
            TextBox txtVINumber = new TextBox();
            TextBox txtPlateNumber = new TextBox();
    
            txtAuto.ID = "txtVehAuto" + i.ToString();
            txtModel.ID = "txtVehModel" + i.ToString();
            txtMiles.ID = "txtVehMilage" + i.ToString();
            txtVINumber.ID = "txtVehVINumber" + i.ToString();
            txtPlateNumber.ID = "txtVehPlate" + i.ToString();
    
            ControlList.Add(txtAuto);
            ControlList.Add(txtModel);
            ControlList.Add(txtMiles);
            ControlList.Add(txtVINumber);
            ControlList.Add(txtPlateNumber);
            phAuto.Controls.Add(txtAuto);
            phModel.Controls.Add(txtModel);
            phMiles.Controls.Add(txtMiles);
            phVINumber.Controls.Add(txtVINumber);
            phPlateNumber.Controls.Add(txtPlateNumber);
    
            dyntxtAuto[i] = txtAuto;
            dyntxtModel[i] = txtModel;
            dyntxtMiles[i] = txtMiles;
            dyntxtVINumber[i] = txtVINumber;
            dyntxtPlateNumber[i] = txtPlateNumber;
    
            LiteralControl literalBreak = new LiteralControl("<br />");
    
            phAuto.Controls.Add(literalBreak);
            phModel.Controls.Add(literalBreak);
            phMiles.Controls.Add(literalBreak);
            phVINumber.Controls.Add(literalBreak);
            phPlateNumber.Controls.Add(literalBreak);
        }
    }
    
    private void RemoveControls(List<Control> ControlList)
    {
        foreach (Control item in ControlList)
        {
            item.Remove();
        }
    }
