    public class CarCell : System.Windows.Forms.DataGridViewTextBoxCell
    {
    	protected override object GetValue(int rowIndex)
    	{
    		Car car = base.GetValue(rowIndex) as Car;
    		if (car != null)
    		{
    			return car.Maker.Name;
    		}
    		else
    		{
    			return "";
    		}
    	}
    }
