     if ((!flag && (column.MaxLength > 0)) && ((column.DataType != DbType.Boolean) && (currentValue.ToString().Length > column.MaxLength)))
            {
                Utility.WriteTrace(string.Format("Max Length Exceeded {0} (can't exceed {1}); current value is set to {2}", column.ColumnName, column.MaxLength, currentValue.ToString().Length));
                this.errorList.Add(string.Format(this.LengthExceptionMessage, str, column.MaxLength));
            }
