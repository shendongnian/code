cs
static void AutoFitColumnsAndRehide(this ExcelRangeBase range)
{
    range.Reset();
    var hiddenColumns = range
        .Select(cell => cell.Start.Column)
        .Distinct()
        .Select(range.Worksheet.Column)
        .Where(column => column.Hidden)
        .ToList();
    range.AutoFitColumns();
    foreach (var column in hiddenColumns)
    {
        column.Hidden = true;
    }
}
This can obviously be adjusted for the 1- and 2-parameter overloads, as well.
