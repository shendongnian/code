                for(int i = 0;i<cat.Count;i++)
                {
                    if (cat[i].table_status == "Available")
                    {
                        BGColor = Color.Green;
                    }
                    else if (cat[i].table_status == "Unavailable")
                    {
                        BGColor = Color.Black;
                    }
                }
