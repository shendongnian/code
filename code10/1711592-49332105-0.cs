    public partial class CalcQ3 : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    
    private static ScientificCalculator calc = new ScientificCalculator();
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        double number;
        bool isNumber = double.TryParse(txtNewNumber.Text, out  number);   // Testing if textbox value is numeric
        if (isNumber)                                                            // if numeric add number to total
        {
            calc.Addition(number);
            lblTotal.Text = (calc.Total).ToString();
        }
        else                                                                     // Display error
        {
            txtNewNumber.Text = string.Empty;
            txtNewNumber.Focus();
            lblTotal.Text = "Please Enter A Numeric Value";
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        calc = new ScientificCalculator();
        calc.Clear();
        lblTotal.Text = (calc.Total).ToString();
    }
}
