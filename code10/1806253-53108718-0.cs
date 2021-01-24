	var auditRecordField = typeof(AuditTrailEntry).GetField("auditRecord", BindingFlags.NonPublic | BindingFlags.Instance);
	var previousValueProperty = auditRecordField.FieldType.GetProperty("PreviousValue", BindingFlags.NonPublic | BindingFlags.Instance);
    
    // ...
    foreach (AuditTrailEntry entry in dataList)
    {
        // ...
    
        var record = auditRecordField.GetValue(entry);
        var value = previousValueProperty.GetValue(record);
    }
