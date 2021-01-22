    <DelimitedRecord(";")> _
    <IgnoreFirst(1)> _
    <IgnoreEmptyLines()> _
    Public Class ClientsClass            
        <FieldConverter(ConverterKind.Date, "dd/M/yyyy"), FieldQuoted(QuoteMode.OptionalForBoth)> Public DateField As Date
        <FieldTrim(TrimMode.Both), FieldQuoted(QuoteMode.OptionalForBoth)> Public ClientCountry As String
        <FieldTrim(TrimMode.Both), FieldQuoted(QuoteMode.OptionalForBoth)> Public AccountId As String
        <FieldTrim(TrimMode.Both), FieldQuoted(QuoteMode.OptionalForBoth)> Public Name As String
        <FieldTrim(TrimMode.Both), FieldQuoted(QuoteMode.OptionalForBoth)> Public FNumber As String
    End Class
