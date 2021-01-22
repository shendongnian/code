                //i = LVPurchase.Items.Count + 1;  
                LVPurchase.Items.Add(cmbService.SelectedValue.ToString(), i);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(cmbService.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(cmbItem.SelectedValue.ToString());
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(cmbItem.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(txtPurchaseQty.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(txtUnitCostUSD.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(txtConvRate.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(txtUnitCostBDT.Text);
                SubTotUSD = Convert.ToDouble(txtPurchaseQty.Text) * Convert.ToDouble(txtUnitCostUSD.Text);
                txtSubTotUSD.Text = SubTotUSD.ToString();
                SubTotBDT = Convert.ToDouble(txtPurchaseQty.Text) * Convert.ToDouble(txtUnitCostBDT.Text);
                txtSubTotBDT.Text = SubTotBDT.ToString();
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(txtSubTotUSD.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(txtSubTotBDT.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(txtBatch.Text);
                LVPurchase.Items[LVPurchase.Items.Count - 1].SubItems.Add(dtpExpiryDate.Value.ToString());
                
                TotalUSD = TotalUSD + SubTotUSD;
                txtTotalUSD.Text = TotalUSD.ToString();
                TotalBDT = TotalBDT + SubTotBDT;
                txtTotalBDT.Text = TotalBDT.ToString();
            }    
