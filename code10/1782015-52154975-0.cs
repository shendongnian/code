    if (!Guid.TryParse(txtCode.Text, out Guid result))
    {
        Console.WriteLine("not a valid guid");
    }
    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = result;
