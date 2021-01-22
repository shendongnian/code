            double parsedValue;
            if (!double.TryParse(height.Text, out parsedValue))
            {
                height.Text = "";
            }
        }
