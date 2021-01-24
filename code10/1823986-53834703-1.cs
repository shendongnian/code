                try
                {
                    if (this.TxtCoach.Text.Contains('A') ||
                        this.TxtCoach.Text.Contains('B') ||
                        this.TxtCoach.Text.Contains('C') ||
                        this.TxtCoach.Text.Contains('D') ||
                        this.TxtCoach.Text.Contains('E') ||
                        this.TxtCoach.Text.Contains('F') ||
                        this.TxtCoach.Text.Contains('G') ||
                        this.TxtCoach.Text.Contains('H'))
                    {
                        LstFinalB.Items.Add(TxtCoach.Text);
                    }
                    else
                    {
                        throw new ArgumentException("Correct your coach is valid!");
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
