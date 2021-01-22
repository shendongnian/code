     public override bool AutoScroll
            {
                get { return false; }
                set
                {
                    if (value)
                        throw new Exception("Auto Scroll not supported in this control");
                    base.AutoScroll = false;
                }
            }
