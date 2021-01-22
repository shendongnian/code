So, if you know that the database file is in the database subfolder of the application folder, you could do something like this (C#): 
        string relativePath = @"database\myfile.s3db";
        string currentPath;
        string absolutePath;
        string connectionString;
        currentPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        absolutepath = System.IO.Path.Combine(currentPath,relativePath);
        connectionString = string.Format("DataSource={0}", absolutePath);
        SQLiteConnection cnn = new SQLiteConnection(connectionString);
