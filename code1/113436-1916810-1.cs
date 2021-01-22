    foreach (RepeaterItem item in variantRepeater.Items)
    {
          decimal quantity = 0;        
          decimal.TryParse(((DropDownList)item.FindControl(
                 "quantityLister")).SelectedValue, out quantity); 
          if (quantity > 0)
          { 
              if (item == null)
                  throw new ApplicationException(
                      "Can't locate RepeaterItem");
              object obj = item.FindControl("variantId");
              if (obj == null)
              {
                  string sNL = Environment.NewLine;
                  StringBuilder sb = new StringBuilder(
                         "Can't locate variantId HiddenField" + sNL +
                         "item Controls are:" + sNL); 
                  foreach(Control ctrl in item.Controls)
                      sb.Append(ctrl.Name + sNL);
                        
                  throw new ApplicationException(sb.ToString());                
              }
              if (!(obj is HiddenField))
                  throw new ApplicationException(
                      "variantId is not a HiddenField");
              HiddenField hfld = obj as HiddenField;
              string variantId = hfld.Value;
              orderForm.LineItems.Add( new LineItem(
                     catalogName, productId, variantId, quantity));
              basketUpdated = true; 
          }
    }
