    public class CarColumn : System.Windows.Forms.DataGridViewTextBoxColumn
    {
    	public CarColumn(): base()
    	{
    		CarCell c = new CarCell();
    		base.CellTemplate = c;
    	}
    }
