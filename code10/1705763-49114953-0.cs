     private void SetDateFormat(object sender, KeyEventArgs e)
        {
            DatePicker dt = (DatePicker)sender;
            string justNumbers = new String(dt.Text.Where(Char.IsDigit).ToArray());
            if (justNumbers.Length == 8)
            {
                string newDate = justNumbers.Insert(2, "/").Insert(5, "/");
                try
                {
                    dt.SelectedDate = DateTime.Parse(newDate);
                }catch(Exception ex)
                {
                    dt.text = "";
                }
            }
        }
