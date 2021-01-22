    using System.Reflection;
    public void Print(object value)
    {
        PropertyInfo[] myPropertyInfo;
        string temp="Properties of "+value+" are:\n";
    	myPropertyInfo = value.GetType().GetProperties();
    	for (int i = 0; i < myPropertyInfo.Length; i++)
    	{
    	    temp+=myPropertyInfo[i].ToString().PadRight(50)+" = "+myPropertyInfo[i].GetValue(value, null)+"\n";
    	}
    	MessageBox.Show(temp);
    }
