    using System;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace WindowsFormsApp1
    {
    	public partial class Form1 : Form
    	{
    		public decimal SumaDepusa;
    		public Excel.Worksheet worksheet;
    		public int row = 1;
    
    		public Form1()
    		{
    			InitializeComponent();
    			var app = new Excel.Application
    			{
    				Visible = true
    			};
    
    			app.Workbooks.Add();
    			worksheet = (Excel.Worksheet)app.ActiveSheet;
    		}
    
    		public void Open()
    		{
    			try
    			{
    				if (decimal.TryParse(textBox1.Text, out var decimalParsed))
    				{
    					SumaDepusa = decimalParsed;
    					worksheet.Cells[row, "A"] = SumaDepusa;
    				}
    				else
    				{
    					MessageBox.Show($"Cannot parse: {textBox1.Text}");
    				}
    			}
    			catch (Exception e)
    			{
    
    				MessageBox.Show($"Error: {e}");
    
    			}
    		}
    
    		private void Button1_Click(object sender, EventArgs e)
    		{
    			Open();
    			row++;
    		}
    	}
    }
