     for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dt.Rows[i][0].ToString() == String.Empty )
                            {
                                dt.Rows.RemoveAt(i);
                            }
                        }
