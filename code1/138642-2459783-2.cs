    MemoryStream _MemoryStream = new System.IO.MemoryStream();
    _Image.Save(_MemoryStream, _ImageFormat);
    SqlParameter _SqlParameter = new 
        SqlParameter("@" + _ImageFieldName, SqlDbType.Image);
    _SqlParameter.Value = _MemoryStream.ToArray();
    _SqlCommand.Parameters.Add(_SqlParameter);
