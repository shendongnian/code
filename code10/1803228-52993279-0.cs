    object sum;
                sum = dt.Compute("Sum(Temps)", "");
                TimeSpan time = TimeSpan.Parse(sum.ToString());
                string timeForDisplay = (int)time.TotalHours + time.ToString(@"\:mm\:ss");
                textBox1.Text = timeForDisplay;
