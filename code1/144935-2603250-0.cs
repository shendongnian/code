private string m_MiddleName;
public string MiddleName
{
  get { return m_MiddleName; }
  set { m_MiddleName = value; }
}
.
.
.
public static void AddParameter(SQLCommand cmd, string parameterName, SQLDataType dataType, object value)
{
  SQLParameter param = cmd.Parameters.Add(parameterName, dataType);
  if (value is string) { // include other non-nullable datatypes
    if (value == null) {
      param.value = DBNull.Value;
    } else {
      param.value = value;
    }
  } else { // nullable data types
    if (value.HasValue) {
          param.value = value;
    } else {
          param.value = DBNull.Value;
    }
  }
}
.
.
.
AddParameter(cmd, "@MiddleName", SqlDbType.VarChar, MiddleName);
