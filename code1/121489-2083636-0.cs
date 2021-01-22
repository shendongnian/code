            private bool dirty = false;
            private int currentRowIndex;
            void Products_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
            {
               currentRowIndex=ProductsViewSource.View.CurrentPosition;
                int i=0;
                foreach (object o in originalProducts[currentRowIndex].ItemArray)
                {
                    if (o.Equals(restouranDataSet.Products[currentRowIndex].ItemArray[i]))
                        dirty = false;
                    else
                    {
                        dirty = true;
                        return;
                    }
                    i++;
                }
            }
