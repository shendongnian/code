    if (!string.IsNullOrEmpy(txtBags.Text) && !string.IsNullOrEmpty(PackingBox.Text))
    {
        if (!Decimal.TryParse(txtBags.Text, out var bags))
        {
            // handle parse failure
            return;
        }
        if (!Decimal.TryParse(PackingBox.Text, out var packingBox))
        {
            // handle parse failure
            return;
        }
        txtQty.Text = (bags * packingBox / 100).ToString();
    }
