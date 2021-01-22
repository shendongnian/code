    using Microsoft.VisualBasic.PowerPacks.Printing;
    private void printButton_Click(object sender, EventArgs e)
    {
       printForm1.Print(this, PrintForm.PrintOption.ClientAreaOnly);
    }
