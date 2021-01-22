    public partial class Form1 : Form
    {
            xlsLayout xlLayout = new xlsLayout();
                xl.SetCell(xlLayout.xlFileColumn, xlLayout.xlHeaderRow, "File Name");
                xl.SetCell(xlLayout.xlFieldColumn, xlLayout.xlHeaderRow, "Code field name");
                xl.SetCell(xlLayout.xlFreindlyNameColumn, xlLayout.xlHeaderRow, "Freindly name");
                xl.SetCell(xlLayout.xlHelpTextColumn, xlLayout.xlHeaderRow, "Inline Help Text");
    }
