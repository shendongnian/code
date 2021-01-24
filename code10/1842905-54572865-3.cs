    public List<EntryTable> Tables { get; private set; }
    public List<BufferElement> Buffer { get; private set; }
     string Query = string.Empty;
                        for (int i = 0; i < Tables[0].PrimaryKeys.Count; i++)
                        {
                            Query += "(";
                            for (int j = 0; j < i; j++)
                            {
                                switch (Tables[0].PrimaryKeys[j].CLRType)
                                {
                                    case CLRType.CLR_BYTE:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToByte(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_INT16:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToInt16(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_INT32:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToInt32(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_INT64:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToInt64(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_SINGLE:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToSingle(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_DOUBLE:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToDouble(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_DECIMAL:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToDecimal(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_Boolean:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = {Convert.ToBoolean(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)} AND ";
                                        break;
                                    case CLRType.CLR_STRING:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = '{Convert.ToString(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)}' AND ";
                                        break;
                                    case CLRType.CLR_DATETIME:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = '{Convert.ToDateTime(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)}' AND ";
                                        break;
                                    case CLRType.CLR_TIME:
                                        Query += $"{Tables[0].PrimaryKeys[j].KeyPart} = '{TimeSpan.Parse(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[j].KeyPart).Value)}' AND ";
                                        break;
                                }
                            }
    
                            switch (Tables[0].PrimaryKeys[i].CLRType)
                            {
                                case CLRType.CLR_BYTE:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToByte(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_INT16:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToInt16(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_INT32:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToInt32(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_INT64:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToInt64(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_SINGLE:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToSingle(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_DOUBLE:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToDouble(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_DECIMAL:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToDecimal(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_Boolean:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > {Convert.ToBoolean(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}";
                                    break;
                                case CLRType.CLR_STRING:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > '{Convert.ToString(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}'";
                                    break;
                                case CLRType.CLR_DATETIME:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > '{Convert.ToDateTime(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}'";
                                    break;
                                case CLRType.CLR_TIME:
                                    Query += $"{Tables[0].PrimaryKeys[i].KeyPart} > '{TimeSpan.Parse(Buffer.Find(x => x.ID == Tables[0].PrimaryKeys[i].KeyPart).Value)}'";
                                    break;
                            }
                            Query += $") {(Tables[0].PrimaryKeys.Count > 1 && i != Tables[0].PrimaryKeys.Count - 1 ? " OR " : string.Empty)} \n";
                        }
    
                        Query += $"ORDER BY {string.Join(" ASC, ", Tables[0].PrimaryKeys.Select(x => x.KeyPart).ToArray())} ASC";
    
                        SelectCommand = $"SELECT TOP 1 * FROM {Tables[0].Table} WHERE " + Query;
