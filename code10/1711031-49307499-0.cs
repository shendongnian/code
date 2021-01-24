    public void FillInComboBox(ComboBox target, int start, int end)
            {
                for(int i = start; i <= end; i++)
                {
                    target.Items.Add(i);
                }
            }
