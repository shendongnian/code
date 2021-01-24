    if (!Guid.TryParse(txtCode.Text, out Guid result))
    {
        Console.WriteLine("not a valid guid");
        return;
    }
    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = result;
