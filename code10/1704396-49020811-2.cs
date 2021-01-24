                    while(rdr.Read())
                    {
                        yield return new Metadata {
                                Id = rdr["id"],
                                Title = rdr["title"],
                                Sku = rdr["sku"],
                                IsLive = rdr["islive"],
                            };
                    }
                    rdr.Close();
                } 
            }
    
        }
    }
