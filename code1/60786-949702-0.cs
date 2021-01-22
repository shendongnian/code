    var rs = dbCmd.ExecuteReader();
    var results = new List<MyDto>();
    while (rs.Read()) {
      results.Add(new MyDto {
        Id = rs.ReadInt("Id"),
        Name = rs.ReadString("Name"),
        ...
      };
    }
