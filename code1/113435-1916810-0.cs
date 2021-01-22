    foreach (RepeaterItem item in variantRepeater.Items)
    {
          decimal quantity = 0;        
          decimal.TryParse(((DropDownList)item.FindControl(
                 "quantityLister")).SelectedValue, out quantity); 
          if (quantity > 0)
          {   
              string variantId = ((HiddenField)item.FindControl("variantId")).Value;
              orderForm.LineItems.Add(
                     new LineItem(catalogName, productId, variantId, quantity));
              basketUpdated = true; 
          }
    }
