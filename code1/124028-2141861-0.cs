    string phoneNumber;
    if (Convert.IsDBNull(sqlDataReader[(int)readerFields.PhoneNumber]) {
      phoneNumber = string.Empty;
    }
    else {
      phoneNumber = sqlDataReader.getString((int)readerFields.PhoneNumber);
    }
