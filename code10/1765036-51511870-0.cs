    connection.Open();
        foreach (var objectItem in items)
        {
            personCmd.Parameters.AddWithValue("@positionX", objectItem.X);
            personCmd.Parameters.AddWithValue("@positionY", objectItem.Y);
            personCmd.Parameters.AddWithValue("@width", objectItem.Width);
            personCmd.Parameters.AddWithValue("@height", objectItem.Height);
            personCmd.Parameters.AddWithValue("@confidence", objectItem.Confidence);
            personCmd.ExecuteNonQuery();
            personCmd.Parameters.Clear();
        }
        connection.Close();
    
