            public Dictionary<int, List<string>> getContactListAddContacts()
            {
               //get db stuff
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt.AsEnumerable()
                    .GroupBy(x => x.Field<int>("table1_id"), y => y.Field<string>("table2_id"))
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
