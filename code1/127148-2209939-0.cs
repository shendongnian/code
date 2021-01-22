    private string Serialize<TEntity>(TEntity instance)
    {
        try
        {
            XmlSerializer xs = new XmlSerializer(typeof(TEntity));
            using (System.IO.StringWriter writer = new System.IO.StringWriter())
            {
                xs.Serialize(writer, instance);
                return writer.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    } 
