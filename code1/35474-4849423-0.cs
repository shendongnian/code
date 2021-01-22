                        t = new ToolTip();
                      
                    }
                    t.IsBalloon = true;
                    t.ToolTipTitle = "Stop";
                    t.ToolTipIcon = ToolTipIcon.Error;
                    t.Show("", yourControlonWhichToApplyToolTip, 0);
                    
                    t.Show("PDescription", yourControlonWhichToApplyToolTip, 1000);
