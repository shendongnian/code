    MemoryStream _MemoryStream = new System.IO.MemoryStream();
    _Image.Save(_MemoryStream, _ImageFormat);
    _MemoryStream.Position = 0;  // I *think* you need this
    SqlParameter _SqlParameter = new 
        SqlParameter("@" + _ImageFieldName, SqlDbType.VarBinary);
    _SqlParameter.Value = new SqlBytes(_MemoryStream);
    _SqlCommand.Parameters.Add(_SqlParameter);
