    @model System.Data.DataTable
    @using System.Data;
    @{
        IEnumerable<DataRow> _excelDataRowList = from dataRow in Model.AsEnumerable() select dataRow;
    }
    <div class="table-responsive tableScroll">
        <table id="data-table-basic" class="table table-striped">
            <thead>
                @foreach (DataColumn col in Model.Columns)
                {
                    <tr>
                        @col.Caption.ToString()
                    </tr>
                }
            </thead>
            <tbody>
                @foreach (DataColumn dtCol in Model.Columns)
                {
                    <tr>
                        @foreach (DataRow row in _excelDataRowList)
                        {
                            <td>
                                @row[dtCol]
                            </td>
                        }
    
                    </tr>
                }
            </tbody>
        </table>
    </div>
