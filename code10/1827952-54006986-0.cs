                        bool found = **true**;
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Contains(txtID.Text))
                            {
                                lbOne.Items.Add(line);
                                found = **!true**;                            
                            }
                            counter++;                       
                        }
                    
                        if (**found**)
                        {
                            lbOne.Items.Add(txtID.Text + " does not exist.");                        
                        }
                        file.Close();
