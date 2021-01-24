        private void Form1_Load(object sender, EventArgs e)
        {
            lblOutput.Text = GenerateSquare(5);
        }
        private string GenerateSquare(int n)
        {
            string square = "";
            for (int w = 0; w < n; w++)
            {
                for (int h = 0; h < n; h++)
                {
                    // top or bottom line
                    if (w == 0 || w == n - 1)
                    {
                        square += "x";
                    }
                    else // sides
                    {
                        if (h == 0 || h == n - 1)
                        {
                            square += "x";
                        }
                        else square += " ";
                    }
                    // change line 
                    if (h == n - 1)
                        square += "\n";
                }
            }
            return square;
        }
