    private readonly DataContractToSerialize _testContract =
        new DataContractToSerialize
            {
                ID = 1,
                Name = "One",
                Children =
                    {
                        new ChildClassToSerialize {ChildMember = "ChildOne"},
                        new ChildClassToSerialize {ChildMember = "ChildTwo"}
                    }
            };
    public void SerializeDataContract()
    {
        using (var outputStream = new MemoryStream())
        {
            using (var writer = XmlWriter.Create(outputStream))
            {
                var serializer =
                    new DataContractSerializer(_testContract.GetType());
                if (writer != null)
                {
                    serializer.WriteObject(writer, _testContract);
                }
            }
            outputStream.Position = 0;
            using (
                var conn =
                    new SqlConnection(Settings.Default.ConnectionString))
            {
                conn.Open();
                const string INSERT_COMMAND =
                    @"INSERT INTO XmlStore (Data) VALUES (@Data)";
                using (var cmd = new SqlCommand(INSERT_COMMAND, conn))
                {
                    using (var reader = XmlReader.Create(outputStream))
                    {
                        var xml = new SqlXml(reader);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Data", xml);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
