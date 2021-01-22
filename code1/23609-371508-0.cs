    message CsvFile {
        repeated CsvHeader header = 1;
        repeated CsvRow row = 2;
    }
    
    message CsvHeader {
        require string name = 1;
        require ColumnType type = 2;
    }
    
    enum ColumnType {
        DECIMAL = 1;
        STRING = 2;
    }
    
    message CsvRow {
        repeated CsvValue value = 1;
    }
    // Note that the column is implicit based on position within row    
    message CsvValue {
        optional string string_value = 1;
        optional Decimal decimal_value = 2;
    }
    
    message Decimal {
        // However you want to represent it (there are various options here)
    }
