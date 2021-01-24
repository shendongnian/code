       private decimal OilandLubeCosts()
        {
            decimal OilLubeTotal = 0; //default value for the total in the groupbox.
            {
                if (chkOilChange.Checked)  // if user wants an Oil Change for $28
                {
                    OilLubeTotal += 26.00m;
                    lblServiceandLabor.Text = OilLubeTotal.ToString("C");
                }
                if (chkLubeJob.Checked) // if user wants Lube Job for $18.00     // if user wants both, then it simply adds onto totals.
                {
                    OilLubeTotal += 18.00m;
                    lblServiceandLabor.Text = OilLubeTotal.ToString("C");
                    return OilLubeTotal;    // return the checked amounts by adding and sending to OilandLubeCharges.
                }
                else
                {
                    return OilLubeTotal; // return values even if none are checked.
                }
            }
    
        }
        private decimal FlushCosts()
        {
            decimal FlushTotal = 0;
            {
                if (chkRadiator.Checked)
                {
                    FlushTotal += 30.00m;
                    lblServiceandLabor.Text = FlushTotal.ToString("C");
                }
                if (chkTransmission.Checked)
                {
                    FlushTotal += 80.00m;
                    lblServiceandLabor.Text = FlushTotal.ToString("C");
                    return FlushTotal;
                }
                else
                {
                    return FlushTotal;
                }
            }
        }
        private decimal MiscCosts()
        {
            decimal MiscTotal = 0;
            {
                if (chkInspection.Checked)
                {
                    MiscTotal += 15.00m;
                    lblServiceandLabor.Text = MiscTotal.ToString("C");
                }
                if (chkReplaceMuffler.Checked)
                {
                    MiscTotal += 100.00m;
                    lblServiceandLabor.Text = MiscTotal.ToString("C");
                }
                if (chkTireRotation.Checked)
                {
                    MiscTotal += 20.00m;
                    lblServiceandLabor.Text = MiscTotal.ToString("C");
                    return MiscTotal;
                }
                else
                {
                    return MiscTotal;
                }
            }
        }
        private decimal PartsandLaborCharges()
        {
            decimal OtherCharges = 0;
    
            {
    
                if (double.TryParse(txtLabor.Text, out double LaborCost))
                {
                    lblServiceandLabor.Text = LaborCost.ToString("C");
                    // exception handling! If the user types in the labor textbox and receives an error out of Labor Costs, throw error.
    
                    OtherCharges = LaborCost;
                }
            }
            if (decimal.TryParse(txtParts.Text, out decimal PartsCost))
            {
                lblServiceandLabor.Text = PartsCost.ToString("C");
                OtherCharges = PartsCost;           // we want our output to be based on PartsCost as well.
                return OtherCharges;                    // we take everything we added to our bill and sent the numbers back to our Other Charges.
            }
            else
            {
                return OtherCharges;
            }
        }
        private decimal Taxes()
        {
            decimal PlusTaxes;
            decimal PartsBought = Convert.ToDecimal(txtParts.Text);
    
            PlusTaxes = PartsBought * 0.06m;
            lblTaxonParts.Text = PlusTaxes.ToString("C");
            // Have to use decimal because we cannot convert. m = money. So cents.
            return PlusTaxes; // take the added price and sent back to reference.
        }
        private decimal TotalAmountCharged()
        {
            decimal TotalServiceFee;
    
            TotalServiceFee = OilandLubeCosts() + MiscCosts() + FlushCosts() + PartsandLaborCharges() + Taxes();
            //we take everything added up and apply to Total for complete pricing.
            lblTotalFees.Text = TotalServiceFee.ToString("C");
            return TotalServiceFee;
        }
    
    
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            OilandLubeCosts();
            FlushCosts();
            MiscCosts();
            PartsandLaborCharges();
            Taxes();                               // we want to take what we called up there, get totals, and display when we press calculate.
        }
