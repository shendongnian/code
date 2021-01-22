            string temp = " 3 .x£";
            string numbersOnly = String.Empty;
            int tempInt;
            for (int i = 0; i < temp.Length; i++)
            {
                if (Int32.TryParse(Convert.ToString(temp[i]), out tempInt))
                {
                    numbersOnly += temp[i];
                }
            }
            Int32.TryParse(numbersOnly, out tempInt);
            MessageBox.Show(tempInt.ToString());
