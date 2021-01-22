     static ToType GenericConvert<ToType>(object value)
            {
                ToType convValue = default(ToType);
    
                if (!Convert.IsDBNull(value))
                    convValue = (ToType)value;
    
                return convValue;
            }
    MyObject pymt = new MyObject();
    pymt.xcol1id= GenericConvert<int>(row["col1id"]);
    pymt.xcold2id= GenericConvert<string>(row["col2id"]) ?? String.Empty;
    pymt.xcold3id = GenericConvert<decimal>(row["CustNum"]);
