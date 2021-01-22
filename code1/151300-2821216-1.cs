    BoundField bdfRaisedDate = new BoundField();
    clsUtilities.SetBoundFieldCenter(ref bdfRaisedDate, "RaisedDateShort",    "Opened", "RaisedDate");
    grdIssues.Columns.Add(bdfRaisedDate);
    grdIssues.DataSource = mdtIssues;
    grdIssues.DataBind();
    public static void SetBoundFieldCenter(ref BoundField bdfAny, string pDataField, string pHeadingValue, string  pSortExpression)
    {
          bdfAny.DataField = pDataField;
          bdfAny.HeaderText = pHeadingValue;
          bdfAny.SortExpression = pSortExpression;
          bdfAny.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
          bdfAny.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
    }
