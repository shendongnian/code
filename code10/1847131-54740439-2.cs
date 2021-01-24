            var slices = GetSlices();
            if (slices.Any(s => s == "XXX"))
            {
                MessageBox.Show("X Won!");
            }
            if (slices.Any(s => s == "OOO"))
            {
                MessageBox.Show("O Won!");
            }
