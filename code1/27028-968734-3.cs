    SQL Server data type          CLR data type (SQL Server)    CLR data type (.NET Framework)  
    varbinary                     SqlBytes, SqlBinary           Byte[]  
    binary                        SqlBytes, SqlBinary           Byte[]  
    varbinary(1), binary(1)       SqlBytes, SqlBinary           byte, Byte[] 
    image                         None                          None
    
    varchar                       None                          None
    char                          None                          None
    nvarchar(1), nchar(1)         SqlChars, SqlString           Char, String, Char[]     
    nvarchar                      SqlChars, SqlString           String, Char[] 
    nchar                         SqlChars, SqlString           String, Char[] 
    text                          None                          None
    ntext                         None                          None
    
    uniqueidentifier              SqlGuid                       Guid 
    rowversion                    None                          Byte[]  
    bit                           SqlBoolean                    Boolean 
    tinyint                       SqlByte                       Byte 
    smallint                      SqlInt16                      Int16  
    int                           SqlInt32                      Int32  
    bigint                        SqlInt64                      Int64 
    
    smallmoney                    SqlMoney                      Decimal  
    money                         SqlMoney                      Decimal  
    numeric                       SqlDecimal                    Decimal  
    decimal                       SqlDecimal                    Decimal  
    real                          SqlSingle                     Single  
    float                         SqlDouble                     Double  
    
    smalldatetime                 SqlDateTime                   DateTime  
    datetime                      SqlDateTime                   DateTime 
     
    sql_variant                   None                          Object  
    User-defined type(UDT)        None                          user-defined type     
    table                         None                          None 
    cursor                        None                          None
    timestamp                     None                          None 
    xml                           SqlXml                        None
