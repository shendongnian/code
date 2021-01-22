    double val;
            
            if (temp.Text.Split('.').Length > 1)
            {
                val = double.Parse(temp.Text.Split('.')[0]);
                if (temp.Text.Split('.')[1].Length == 1)
                    val += (0.1 * double.Parse(temp.Text.Split('.')[1]));
                else
                    val += (0.01 * double.Parse(temp.Text.Split('.')[1]));
            }
            else
                val = double.Parse(RR(temp.Text));
