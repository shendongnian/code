            if (depth > 10)
                throw new ArgumentException("Cannot search beyond a depth of 10", "depth"); 
            foreach (Control c in Page.Controls)
            {
                if (c.ID == ControlID)
                    return c;
                if (depth > 0)
                {
                    foreach (Control c1 in c.Controls)
                    {
                        if (c1.ID == ControlID)
                            return c1;
                        if (depth > 1)
                        {
                            foreach (Control c2 in c1.Controls)
                            {
                                if (c2.ID == ControlID)
                                    return c2;
                                if (depth > 2)
                                {
                                    foreach (Control c3 in c2.Controls)
                                    {
                                        if (c3.ID == ControlID)
                                            return c3;
                                        if (depth > 3)
                                        {
                                            foreach (Control c4 in c3.Controls)
                                            {
                                                if (c4.ID == ControlID)
                                                    return c4;
                                                if (depth > 4)
                                                {
                                                    foreach (Control c5 in c4.Controls)
                                                    {
                                                        if (c5.ID == ControlID)
                                                            return c5;
                                                        if (depth > 5)
                                                        {
                                                            foreach (Control c6 in c5.Controls)
                                                            {
                                                                if (c6.ID == ControlID)
                                                                    return c6;
                                                                if (depth > 6)
                                                                {
                                                                    foreach (Control c7 in c6.Controls)
                                                                    {
                                                                        if (c7.ID == ControlID)
                                                                            return c7;
                                                                        if (depth > 8)
                                                                        {
                                                                            foreach (Control c8 in c7.Controls)
                                                                            {
                                                                                if (c8.ID == ControlID)
                                                                                    return c8;
                                                                                if (depth > 9)
                                                                                {
                                                                                    foreach (Control c9 in c8.Controls)
                                                                                    {
                                                                                        if (c9.ID == ControlID)
                                                                                            return c9;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                
                }
            }
            return null;
        }
