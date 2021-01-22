            public static int SelectByValue(ComboBox comboBox, string value)
            {
                int i = 0;
                for (i = 0; i <= comboBox.Items.Count - 1; i++)
                {
                    DataRowView cb;
                    cb = (DataRowView)comboBox.Items[i];
                    if (cb.Row.ItemArray[0].ToString() == value)// Change the 0 index if your want to Select by Text as 1 Index
                    {
                        return i;
                    }
                }
                return -1;
            }
