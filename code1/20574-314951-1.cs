        string relativePath = @"database\myfile.s3db";
        string currentPath;
        string absolutePath;
        string connectionString;
        currentPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        absolutePath = System.IO.Path.Combine(currentPath,relativePath);
        connectionString = string.Format("DataSource={0}", absolutePath);
        SQLiteConnection cnn = new SQLiteConnection(connectionString);
