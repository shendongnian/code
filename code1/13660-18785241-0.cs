    private void SortDDL(ref DropDownList objDDL)
    {
    ArrayList textList = new ArrayList();
    ArrayList valueList = new ArrayList();
    foreach (ListItem li in objDDL.Items)
    {
        textList.Add(li.Text);
    }
    textList.Sort();
    foreach (object item in textList)
    {
        string value = objDDL.Items.FindByText(item.ToString()).Value;
        valueList.Add(value);
    }
    objDDL.Items.Clear();
    for(int i = 0; i < textList.Count; i++)
    {
         ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
         objDDL.Items.Add(objItem);
    }
