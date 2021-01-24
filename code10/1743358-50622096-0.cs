    private void ProductButton_Click(object sender, EventArgs e)
            {
                Button ProductButton = sender as Button;
                DataAccess dataAccess = new DataAccess();
                int ProductID = Convert.ToInt32(ProductButton.Tag);
    
                Details details = dataAccess.ReadProductDetails(ProductID);
    
                decimal price = details.Price;
    
                string foundItem = CheckProductInListBox(details.Name);
                if (!String.IsNullOrEmpty(foundItem))
                {
                    string currentPriceString = foundItem.Replace(details.Name.PadRight(30), "");
                    decimal currentPriceValue;
    
                    if (Decimal.TryParse(currentPriceString, out currentPriceValue))
                    {
                        currentPriceValue += price;
                        string newItem = details.Name.PadRight(30) + currentPriceValue.ToString();
    
                        int index = listBox1.Items.IndexOf(foundItem);
                        listBox1.Items[index] = newItem;
                    }
                    else
                    {
                        //Throw error
                    }
    
                }
                else
                {
                    listBox1.Items.Add(details.Name.PadRight(30) + details.Price.ToString());
                }
            }
    
    
            private string CheckProductInListBox(string name)
            {
                foreach (string item in listBox1.Items)
                {
                    if (item.Contains(name))
                    {
                        return item;
                    }
                }
                return String.Empty;
            }
