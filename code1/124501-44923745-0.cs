           class emp
            {
                public int empid { get; set; }
                public string name { get; set; }
                public static emp create(IDataRecord record)
                {
                    return new emp
                    {
                        empid = Convert.ToInt32(record["Pk_HotelId"]),
                        name = record["HotelName"].ToString()
                    };
                }
            }
