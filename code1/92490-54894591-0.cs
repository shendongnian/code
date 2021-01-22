                4,3,4,3,8
            };
            int fac = 1;
            int[] facs = new int[array.Length+1];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array[i]; j > 0; j--)
                {
                    fac *= j;
                }
                facs[i] = fac;
                textBox1.Text += facs[i].ToString() + " ";
                fac = 1;
            }`
