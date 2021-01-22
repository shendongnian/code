            val = System.Enum.Parse(this.enumType, rb.Text) as System.Enum;
        object obj = this.bindingSource.Current;
        obj.GetType().GetProperty(propertyName).SetValue(obj, val, new object[] { });
        this.bindingSource.CurrencyManager.Refresh();
        }
        catch(Exception ex)
        {
            // cannot occurred if code is safe
            System.Windows.Forms.MessageBox.Show("No enum value for this radio button : " + ex.ToString());
        }
