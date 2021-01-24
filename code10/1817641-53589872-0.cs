    var data2 = dt.AsEnumerable().Select(x => new
            {
                SubTask = x.Field<string>("subtask"),
                Name = x.Field<string>("FirstName"),
                Date = x.Field<string>("Day") + ", " + x.Field<string>("Date"),
                Hour = System.Text.Encoding.UTF8.GetString(x.Field<System.Byte[]>("EmpHours"))
            }).ToList();
