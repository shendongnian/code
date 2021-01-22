            foreach (var c in this.Controls)
            {
                if (c is Label)
                {
                    var x = (Label)c;
                    if (x.Name == "label1")
                    {
                        x.Text = "WE FOUND YOU";
                        break;
                    }
                }
            }
