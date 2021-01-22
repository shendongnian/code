    public void setComments(String comments)
            {
                String[] aux;
                if(comments.Contains('\n')) //Multiple lines comments
                {
                    aux = comments.Split('\n');
                    for (int i = 0; i < aux.Length; i++)
                        this.textBoxComments.Text += aux[i] + Environment.NewLine;  
                }
                else //One line comments
                    this.textBoxComments.Text = comments;
            }
