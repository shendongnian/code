    private void AddButton() { 
                                if(this.InvokeRequired){
                                    Invoke((MethodInvoker)delegate ()
                                    {
                                        Random random = new Random(2);
                                        Thread.Sleep(20);
                                        Button button = new Button();
                                        button.Size = new Size(50,50);
                                        button.Location = new 
                                        Point(random.Next(this.Width),random.Next(this.Height));
                                        this.Controls.Add(button);
                                 });
                                
                            }
