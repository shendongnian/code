        using System.Reflection;
        public void Print(object value)
    {
        PropertyInfo[] myPropertyInfo;
        string temp="Properties of "+value+" are:\r\n";
    	myPropertyInfo = value.GetType().GetProperties();
	for (int i = 0; i < myPropertyInfo.Length; i++)
	{
	    temp+=myPropertyInfo[i].Name+":  "+myPropertyInfo[i].ToString()+"\n";
	    temp+="   value = "+myPropertyInfo[i].GetValue(value, null)+"\n";
	}
    	MessageBox.Show(temp);
    }
