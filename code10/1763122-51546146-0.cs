    [Test, Description("Roundtrips a two-dimensional array of ints")]
    public void TwoDimensionalInts()
    {
        using (var conn = OpenConnection())
        using (var cmd = new NpgsqlCommand("SELECT @p1, @p2", conn))
        {
            var expected = new[,] { { 1, 2, 3 }, { 7, 8, 9 } };
            var p1 = new NpgsqlParameter("p1", NpgsqlDbType.Array | NpgsqlDbType.Integer);
            var p2 = new NpgsqlParameter { ParameterName = "p2", Value = expected };
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            p1.Value = expected;
            var reader = cmd.ExecuteReader();
            reader.Read();
            Assert.That(reader.GetValue(0), Is.EqualTo(expected));
            Assert.That(reader.GetProviderSpecificValue(0), Is.EqualTo(expected));
            Assert.That(reader.GetFieldValue<int[,]>(0), Is.EqualTo(expected));
        }
    }
